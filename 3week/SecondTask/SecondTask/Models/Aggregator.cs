using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask.Models
{
    public class Aggregator
    {
        private IEnumerable<Photo> photos;


        public void Read()
        {
            using (WebClient wc = new())
            {
                var json = wc.DownloadString("https://jsonplaceholder.typicode.com/photos");
                if (json == null)
                    throw new NullReferenceException();
                photos = JsonConvert.DeserializeObject<List<Photo>>(json);
            }
        }
        public void Download()
        {
            foreach (var item in photos)
            {
                item.Download();
            }
        }
    }
}
