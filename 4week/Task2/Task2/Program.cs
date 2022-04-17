// See https://aka.ms/new-console-template for more information
using Task2.Models;

Console.WriteLine("Hello, World!");
string destinationFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Files";
Downloader downloader = new Downloader();

var result3 = downloader.Download("https://via.placeholder.com/150/d32776", destinationFolder, 8);
var result = downloader.Download("https://via.placeholder.com/150/24f355", destinationFolder, 4);
var result2 = downloader.Download("https://via.placeholder.com/150/92c952", destinationFolder, 6);

Console.WriteLine($"Location: {result.FilePath}");
Console.WriteLine($"Size: {result.Size}bytes");
Console.WriteLine($"Time taken: {result.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result.ParallelDownloads}");
Console.WriteLine($"Location: {result2.FilePath}");
Console.WriteLine($"Size: {result2.Size}bytes");
Console.WriteLine($"Time taken: {result2.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result2.ParallelDownloads}");
Console.WriteLine($"Location: {result3.FilePath}");
Console.WriteLine($"Size: {result3.Size}bytes");
Console.WriteLine($"Time taken: {result3.TimeTaken.Milliseconds}ms");
Console.WriteLine($"Parallel: {result3.ParallelDownloads}");

Console.ReadKey();
