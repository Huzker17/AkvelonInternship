using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Store
    {
        public string Name { get; private set; }

        public Store(string name)
        {
            Name = name;
        }
    }
}
