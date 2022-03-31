using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;
using TextEditor.Models;

namespace TextEditor.Operations
{
    public class CreateANewRow : IOperation
    {
        private TextClass receiver;
        public CreateANewRow(TextClass receiver) => this.receiver = receiver;

        public void Execute()
        {
            receiver.CreateNewRow();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
