using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;
using TextEditor.Models;


namespace TextEditor.Operations
{
    public class Delete : IOperation
    {
        private TextClass _receiver;
        private char deleted;

        public Delete(TextClass receiver) => _receiver = receiver;

        public void Execute()
        {
            this.deleted = _receiver.Delete();
        }
        public void Undo()
        {
            _receiver.InsertChar(deleted);
        }
        public void Redo()
        {
            this.deleted = _receiver.Delete();
        }
    }
}
