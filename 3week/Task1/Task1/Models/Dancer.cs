using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class Dancer
    {
        public string? DanceType { get; private set; }

        private void Dance(string musicType)
        {
            if(musicType == null)
                return;
            if (musicType == "Hardbass")
                this.DanceType = "Elbow for Hardbass";
            if (musicType == "Latino")
                this.DanceType = "Hips for Latino";
            if (musicType == "Rock")
                this.DanceType = "Head for Rock";
            Console.WriteLine("Dance type: " + this.DanceType);
        }
        public void Dancing(string musciType)
        {
            Thread thread = new Thread(() => this.Dance(musciType));
            thread.Start();
        }
    }
}
