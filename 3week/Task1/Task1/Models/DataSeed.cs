using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class DataSeed
    {
        public IEnumerable<Dancer> DancerList()
        {
            var dancers = new List<Dancer>()
            {
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer()
            };
                return dancers;
         }
        public IEnumerable<Music> PlayList()
        {
              var playList = new List<Music>()
            {
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Latino"),
                new Music("Rock")
            };
            return playList;
        }
    }
}
