// See https://aka.ms/new-console-template for more information
using Task2.Models;

string destinationFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Files";
Downloader downloader = new Downloader();

var result = downloader.Download("https://via.placeholder.com/600/56a8c2", destinationFolder, 5);

Console.WriteLine($"Location: {result.FilePath}");
Console.WriteLine($"Size: {result.Size}bytes");
Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result.ParallelDownloads}");

Console.ReadKey();
