using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;
using TextEditor.Operations;

namespace TextEditor.Models
{
    public class App
    {
        private IOperation operation;

        private TextClass _textClass;
        private IStateManager _stateManager;
        public App(TextClass textClass, IStateManager stateManager)
        {
            _textClass = textClass;
            _stateManager = stateManager;
        }

        public void Undo()
        {
            this.operation = _stateManager.Undo();
                operation.Undo();
            
        }
        public void Redo()
        {
            this.operation = _stateManager.Redo();
            operation.Redo();
        }
        public void InsertChar(char c)
        {
            InsertCharTo command = new InsertCharTo(_textClass,c);
            this.operation = _stateManager.Do(command);
            operation.Execute();
        }
        public void Delete()
        {
            Delete command = new Delete(_textClass);
            operation = _stateManager.Do(command);
            operation.Execute();
        }
        public void MoveCursorTo(int row, int col)
        {
            MoveCursorTo command = new MoveCursorTo(_textClass, row, col);
            this.operation = _stateManager.Do(command);
            operation.Execute();
        }

    }
}
