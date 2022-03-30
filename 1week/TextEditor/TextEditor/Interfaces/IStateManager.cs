using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Interfaces
{
    public interface IStateManager
    {
        public IOperation Undo();
        public IOperation Do(IOperation operation);
        public IOperation Redo();
        public void Reset();
    }
}
