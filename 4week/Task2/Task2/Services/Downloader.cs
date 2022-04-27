using System.Collections.Concurrent;
using System.Net;
using System.Drawing;

namespace Task2.Models
{
    public class Downloader
    {

        public ResultModel Download(string fileUrl, string destinationFolder, int numberOfParallelism = 0)
        {

            Uri uri = new Uri(fileUrl);

            string destinationFilePath = Path.Combine(destinationFolder, (uri.Segments.Last() + ".png"));

            if (numberOfParallelism <= 0)
            {
                numberOfParallelism = Environment.ProcessorCount;
            }

            WebRequest webRequest = HttpWebRequest.Create(fileUrl);

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
                ConcurrentDictionary<int, string> tempFilesDictionary = new ConcurrentDictionary<int, string>();

                List<Range> readRanges = new List<Range>();
                for (int chunk = 0; chunk < numberOfParallelism - 1; chunk++)
                {
                    var range = new Range()
                    {
                        IndexOfChunk = chunk,
                        Start = chunk * (responseLength / numberOfParallelism),
                        End = ((chunk + 1) * (responseLength / numberOfParallelism)) - 1
                    };
                    readRanges.Add(range);
                }


                readRanges.Add(new Range()
                {
                    IndexOfChunk = readRanges.Count + 1,
                    Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                    End = responseLength - 1
                });


                DateTime startTime = DateTime.Now;

                Parallel.ForEach(readRanges, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelism }, readRange =>
                {
                    HttpWebRequest httpWebRequest = HttpWebRequest.Create(fileUrl) as HttpWebRequest;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.AddRange(readRange.Start, readRange.End);
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        String tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            httpWebResponse.GetResponseStream().CopyTo(fileStream);
                            tempFilesDictionary.TryAdd(readRange.IndexOfChunk, tempFilePath);
                        }
                    }
                    using (var progress = new ProgressBar())
                    {
                        for (int j = 0; j <= 100; j++)
                        {
                            progress.Report((double)j / 100);
                            Thread.Sleep(10);
                        }
                    }
                });

                ResultModel result = new ResultModel(destinationFilePath, responseLength, DateTime.Now.Subtract(startTime), readRanges.Count);
                
                using (destinationStream)
                {
                    foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
                    {
                        byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                        destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                        File.Delete(tempFile.Value);
                    }
                }

                return result;
            }
        }
    }
}