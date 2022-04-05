// See https://aka.ms/new-console-template for more information
using LINQ.Services;

Console.WriteLine("Hello, World!");
DataSeed dataSeed = new DataSeed();
Filtration ft = new Filtration(dataSeed);
ft.FilterByLinq();
