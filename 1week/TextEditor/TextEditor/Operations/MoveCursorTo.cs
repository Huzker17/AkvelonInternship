using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor.Operations
{
    public class MoveCursorTo : IOperation
    {
        private TextClass _receiver;
        private readonly int Row;
        private readonly int Column;

        public MoveCursorTo(TextClass receiver, int row, int column)
        {
            _receiver = receiver;
            Row = row;
            Column = column;
        }

        public void Execute()
        {
            _receiver.MoveCursorTo(Row, Column);
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
    }
}
