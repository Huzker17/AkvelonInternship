using Newtonsoft.Json;
using System.Net;

namespace SecondTask.Models
{
    public class Downloader
    {
        public List<Photo> photos { get; private set; }
        public string path { get; private set; }

        public Downloader(string path)
        {
            this.path = path;
        }

        private void Read()
        {
            if (path == null)
                throw new ArgumentNullException();
            using (WebClient wc = new())
            {
                var json = wc.DownloadString(path);
                if (json == null)
                    throw new NullReferenceException();
                photos = JsonConvert.DeserializeObject<List<Photo>>(json);
            }
        }
 
 
        private void DownloadWithThreadPool()
        {
            int inWorker = 3;
            int outWorker = 3;
            ThreadPool.GetMaxThreads(out inWorker, out outWorker);
            foreach (var item in photos)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(item.DownloadWithThreadPool));
            }
        }

        public void ReadAndDownloadWithThreadPool()
        {
            Read();
            DownloadWithThreadPool();
        }

    }
}
