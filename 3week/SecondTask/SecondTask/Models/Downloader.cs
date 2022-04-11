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
            if(path == null)
                throw new ArgumentNullException();
            using (WebClient wc = new())
            {
                var json = wc.DownloadString(path);
                if (json == null)
                    throw new NullReferenceException();
                photos = JsonConvert.DeserializeObject<List<Photo>>(json);
            }
        }
        private void Download()
        {
            if(photos == null)
                throw new ArgumentNullException();
            if(photos.Count == 0)
                throw new ArgumentException();
            foreach (var item in photos)
            {
                item.Download();
            }
        }

        public void ReadAndDownload()
        { 
            Read();
            Download();
        }
        private void DownloadWithThreadPool()
        {
            foreach(var item in photos)
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
