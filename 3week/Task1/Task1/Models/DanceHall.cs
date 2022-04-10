using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class DanceHall
    {
        private string musicType;
        public List<Dancer> Dancers { get; private set; }
        public List<Music> Music { get; private set; }

        public DanceHall(List<Dancer> dancers, List<Music> musics)
        {
            Dancers = dancers;
            Music = musics;
        }

        public void PlayMusicAndDance()
        {
            if (Music == null || Dancers == null)
                throw new ArgumentNullException();
            while (Music.Count > 0)
            {
                this.musicType = PlayAMusic();
                foreach (var dancer in Dancers)
                {
                    this.Dancing(dancer, musicType);
                }
            }
        }
        private string PlayAMusic()
        {
            Thread thread = new Thread(() => this.musicType = ChangeMusic());
            thread.Start();
            return this.musicType;
        }
        private string ChangeMusic()
        {
            if (Music.Count > 0)
            {
                var musicType = Music[(Music.Count - 1)].Type;
                Music.Remove(Music[(Music.Count - 1)]);
                Console.WriteLine("Music type: " + musicType);
                return musicType;
            }
            else
                return null;
        }
        private void Dancing(Dancer dancer, string musicType)
        {
            Thread thread1 = new Thread(() => dancer.Dance(musicType));
            thread1.Start();
        }
       
      
    }
}
