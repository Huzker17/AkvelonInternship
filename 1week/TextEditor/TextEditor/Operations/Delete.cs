using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor.Operations
{
    public class Delete : IOperation
    {
        private TextClass _receiver;

        public Delete(TextClass receiver) => _receiver = receiver;

        public void Execute()
        {
            _receiver.Delete();
        }
        public void Undo()
        {
            _receiver.InsertChar(_receiver.History.Peek());
        }
        public void Redo()
        {
            _receiver.Delete();
        }
    }
}
