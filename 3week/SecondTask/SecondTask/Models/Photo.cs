using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask.Models
{
    public class Photo
    {
        public int AlbumId { get; private set; }
        public int Id { get;  private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }
        public string ThumbnailUrl { get;  private set; }

        public Photo(int albumId, int id, string title, string url, string thumbnailUrl)
        {
            AlbumId = albumId;
            Id = id;
            Title = title;
            Url = url;
            ThumbnailUrl = thumbnailUrl;
        }
        private void Downloading()
        {
            var uri = new Uri(ThumbnailUrl);
            WebClient myWebClient = new();
            {
                myWebClient.DownloadFile(uri,Title + ".png");
            }
        }
        public void Download()
        {
            Thread thread = new Thread(() => Downloading());
            thread.Start();
        }
    }
}
