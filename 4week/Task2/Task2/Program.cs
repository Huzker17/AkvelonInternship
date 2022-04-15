// See https://aka.ms/new-console-template for more information
using Task2.Models;

Console.WriteLine("Hello, World!");
var destinationFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Files";
Downloader downloader = new Downloader();
downloader.Download("https://via.placeholder.com/600/92c952", destinationFolder);
