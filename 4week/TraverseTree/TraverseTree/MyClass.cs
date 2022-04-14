using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraverseTree
{
    public class MyClass
    {
        public string Name { get; private set; }
        public int Number { get;private set; }

        public MyClass(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}
