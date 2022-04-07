using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class Music
    {
        public string Type { get; private set; }
        public Music(string musicType)
        {
            this.Type = musicType;
        }

    }
}
