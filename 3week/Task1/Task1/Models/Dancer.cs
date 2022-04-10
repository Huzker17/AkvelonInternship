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

        public void Dance(string musicType)
        {
            if (musicType == null)
                return;
            if (musicType == "Hardbass")
                this.DanceType = "Elbow for Hardbass";
            if (musicType == "Latino")
                this.DanceType = "Hips for Latino";
            if (musicType == "Rock")
                this.DanceType = "Head for Rock";
            Console.WriteLine("Dance type: " + this.DanceType + " Thread Id : " + Thread.CurrentThread.ManagedThreadId);
        }

    }
}

