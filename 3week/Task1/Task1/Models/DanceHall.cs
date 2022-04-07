using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class DanceHall
    {

        public List<Dancer> Dancers { get; private set; }
        public List<Music> Music { get; private set; }

        public DanceHall()
        {
            Dancers = DancersList();
            Music = PlayList();
        }

        public void PlayMusicAndDance()
        {
            var musicType = ChangeMusic();
            while (Music.Count > 0)
            {
            Thread musicThread = new Thread(() => musicType = ChangeMusic());
                foreach (var dancer in Dancers)
                {
                    Thread thread = new Thread(() => dancer.Dance(musicType));
                    Thread.Sleep(1000);
                    thread.Start();
                }
                musicThread.Start();
            }

        }
        private string ChangeMusic()
        {
            if (Music.Count > 0)
            {
              var musicType = Music[(Music.Count-1)].Type;
              Music.Remove(Music[(Music.Count - 1)]);
                Console.WriteLine("I'm here "+ musicType +" "+ Music.Count());
              return musicType;
            }else
                return null;
        }
        private List<Dancer> DancersList()
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
                new Dancer(),
                new Dancer(),
                new Dancer(),
                new Dancer(),
            };
            return dancers;
        }
        private List<Music> PlayList()
        {
            var playList = new List<Music>()
            {
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Rock"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Hardbass"),
                new Music("Rock"),
                new Music("Latino"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Rock"),
                new Music("Rock"),
                new Music("Hardbass"),
                new Music("Hardbass"),
                new Music("Hardbass"),
                new Music("Latino"),
                new Music("Latino"),
                new Music("Latino"),
                new Music("Rock"),
                new Music("Latino"),
                new Music("Rock")
            };
            return playList;
        }

    }
}
