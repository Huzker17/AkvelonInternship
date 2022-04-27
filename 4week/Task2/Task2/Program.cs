// See https://aka.ms/new-console-template for more information
using Task2.Models;

string destinationFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Files";
Downloader downloader = new Downloader();

var result = downloader.Download("https://via.placeholder.com/600/56a8c2", destinationFolder, 5);
var result2 = downloader.Download("https://images.wallpaperscraft.ru/image/single/teplohod_more_gory_274897_1920x1080.jpg", destinationFolder, 5);

Console.WriteLine($"Location: {result.FilePath}");
Console.WriteLine($"Size: {result.Size}bytes");
Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result.ParallelDownloads}");

Console.WriteLine($"Location: {result2.FilePath}");
Console.WriteLine($"Size: {result2.Size}bytes");
Console.WriteLine($"Time taken: {result2.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result2.ParallelDownloads}");

Console.ReadKey();
