using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Interfaces
{
    public interface IOperation
    {
        public void Execute();
        public void Undo();
        public void Redo();
    }
}
