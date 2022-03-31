using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;
using TextEditor.Models;

namespace TextEditor.Operations
{
    public class InsertCharTo : IOperation
    {
        
        private TextClass receiver;
        private char _incomingChar;

        public InsertCharTo(TextClass receiver, char IncomingChar)
        {
            this._incomingChar = IncomingChar;
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.InsertChar(_incomingChar);
        }
        public void Undo()
        {
            this._incomingChar = receiver.Delete();
        }
        public void Redo()
        {
            receiver.InsertChar(_incomingChar);
        }
    }
}
