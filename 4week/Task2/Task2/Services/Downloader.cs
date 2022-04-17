using System.Collections.Concurrent;
using System.Net;
using System.Drawing;

namespace Task2.Models
{
    public class Downloader
    {
        private string fireUrl { get; set; }

        public ResultModel Download(string fireUrl, string destinationFolder, int numberOfParallelism = 0)
        {
            this.fireUrl = fireUrl;


            Uri uri = new Uri(fireUrl);

            string destinationFilePath = Path.Combine(destinationFolder, (uri.Segments.Last() + ".png"));

            if (numberOfParallelism <= 0)
            {
                numberOfParallelism = Environment.ProcessorCount;
            }

            WebRequest webRequest = HttpWebRequest.Create(fireUrl);

            webRequest.Method = "HEAD";

            long responseLength;

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));
            }


            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append))
            {
                ConcurrentQueue<string> tempFilesDictionary = new ConcurrentQueue<string>();

                List<Range> readRanges = new List<Range>();
                for (int chunk = 0; chunk < numberOfParallelism - 1; chunk++)
                {
                    var range = new Range()
                    {
                        Start = chunk * (responseLength / numberOfParallelism),
                        End = ((chunk + 1) * (responseLength / numberOfParallelism)) - 1
                    };
                    readRanges.Add(range);
                }

                readRanges.Add(new Range()
                {
                    Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                    End = responseLength - 1
                });

                DateTime startTime = DateTime.Now;

                for (int i = 0; i < readRanges.Count; i++)
                {
                    Parallel.Invoke(async () => MyMethod(tempFilesDictionary, readRanges[i]));
                }
                using (var progress = new ProgressBar())
                {
                    for (int j = 0; j <= 100; j++)
                    {
                        progress.Report((double)j / 100);
                        Thread.Sleep(20);
                    }
                }

                ResultModel result = new ResultModel(destinationFilePath, responseLength, DateTime.Now.Subtract(startTime), readRanges.Count);
               
                foreach (var tempFile in tempFilesDictionary)
                {
                    byte[] tempFileBytes = File.ReadAllBytes(tempFile);
                    using (var ms = new MemoryStream(tempFileBytes))
                    {
                        ms.WriteTo(destinationStream);
                        File.Delete(tempFile);
                    }
                }

                return result;
            }

        }

        private async Task MyMethod(ConcurrentQueue<string> parts, Range range)
        {
            HttpWebRequest httpWebRequest = HttpWebRequest.Create(fireUrl) as HttpWebRequest;
            httpWebRequest.Method = "GET";
            httpWebRequest.AddRange(range.Start, range.End);
            string tempFilePath = Path.GetTempFileName();
            var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write);
            using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                httpWebResponse.GetResponseStream().CopyTo(fileStream);
            }
            using (fileStream)
            {
                parts.Enqueue(tempFilePath);
            }
        }
    }
}