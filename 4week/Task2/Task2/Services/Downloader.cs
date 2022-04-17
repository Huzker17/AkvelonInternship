using System.Collections.Concurrent;
using System.Net;
using System.Drawing;

namespace Task2.Models
{
    public class Downloader
    {
        public  ResultModel Download(string fileUrl, string destinationFolderPath, int numberOfParallelDownloads = 0)
        {

            Uri uri = new Uri(fileUrl);

            string destinationFilePath = Path.Combine(destinationFolderPath, uri.Segments.Last());

            if (numberOfParallelDownloads <= 0)
            {
                numberOfParallelDownloads = Environment.ProcessorCount;
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
                ConcurrentQueue<string> tempFilesDictionary2 = new ConcurrentQueue<string>();

                List<Range> readRanges = new List<Range>();
                for (int chunk = 0; chunk < numberOfParallelDownloads - 1; chunk++)
                {
                    var range = new Range()
                    {
                        Start = chunk * (responseLength / numberOfParallelDownloads),
                        End = ((chunk + 1) * (responseLength / numberOfParallelDownloads)) - 1
                    };
                    readRanges.Add(range);
                }

                readRanges.Add(new Range()
                {
                    Start = readRanges.Any() ? readRanges.Last().End + 1 : 0,
                    End = responseLength - 1
                });

                DateTime startTime = DateTime.Now;

                Parallel.ForEach(readRanges, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads },
                    readRange =>
                {
                    HttpWebRequest httpWebRequest = HttpWebRequest.Create(fileUrl) as HttpWebRequest;
                    httpWebRequest.Method = "GET";
                    httpWebRequest.AddRange(readRange.Start, readRange.End);
                    using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                    {
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                        {
                            httpWebResponse.GetResponseStream().CopyTo(fileStream);
                            tempFilesDictionary2.Enqueue(tempFilePath);
                        }
                    }
                });

                ResultModel result = new ResultModel(destinationFilePath, responseLength, DateTime.Now.Subtract(startTime), readRanges.Count);
                foreach (var tempFile in tempFilesDictionary2)
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
    }
}