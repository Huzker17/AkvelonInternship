// See https://aka.ms/new-console-template for more information
using StateMachine.Models;
using System.Net;

Console.WriteLine("Hello, World!");
WebClient wc = new WebClient();
Photo ph = new Photo();
var res = ph.Download("https://via.placeholder.com/600/56a8c2", null);
Console.WriteLine(res.IsCompleted);