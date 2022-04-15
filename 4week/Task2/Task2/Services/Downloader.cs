using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                ConcurrentDictionary<int, string> tempFilesDictionary = new ConcurrentDictionary<int, string>();

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


                int index = 0;
                Parallel.ForEach(readRanges, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads }, readRange =>
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
                            tempFilesDictionary.TryAdd((int)index, tempFilePath);
                        }
                    }
                    index++;

                });

                ResultModel result = new ResultModel(destinationFilePath, responseLength, DateTime.Now.Subtract(startTime), index);


                foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
                {
                    byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                    Image ret = Image.FromStream(tempFileBytes);
                    File.Delete(tempFile.Value);
                }

                return result;
            }


        }
    }
}