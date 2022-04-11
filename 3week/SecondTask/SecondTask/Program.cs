// See https://aka.ms/new-console-template for more information
using SecondTask.Models;

//But this is slower than the way I use to download
//Try to call both of them separately and check.
//Average speed of downloading without ThreadPool is 50 seconds
//Average speed of downloading with ThreadPool is 3 minutes

Console.WriteLine("Hello, World!");
Downloader donwloader = new Downloader(null);
donwloader.ReadAndDownload();

//Aggregator.ReadAndDownloadWithThreadPool();

