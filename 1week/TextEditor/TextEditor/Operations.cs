using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class Operations
    {
        private Stack<char> _UndoActionsCollection =
            new Stack<char>();
        private Stack<char> _RedoActionsCollection =
                    new Stack<char>();
        public void Undo(char c)
        {
            _UndoActionsCollection.Push(c);
        }
    }
}
