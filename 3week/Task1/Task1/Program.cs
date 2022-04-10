// See https://aka.ms/new-console-template for more information
using Task1.Models;

Console.WriteLine("Hello, World!");
DataSeed seed = new DataSeed();
var dancers = seed.DancerList();
var playlist = seed.PlayList();
DanceHall DanceHall = new DanceHall(dancers.ToList(), playlist.ToList());
DanceHall.PlayMusicAndDance();
