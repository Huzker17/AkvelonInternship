using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class ResultModel
    {
        public long Size { get; private set; }
        public string FilePath { get; private set; }
        public TimeSpan TimeTaken { get; private set; }
        public int ParallelDownloads { get; private set; }

        public ResultModel(string filePath, long size, TimeSpan time, int AmountOfParallels)
        {
            FilePath = filePath;
            Size = size;
            TimeTaken = time;
            ParallelDownloads = AmountOfParallels;
        }

    }
}
