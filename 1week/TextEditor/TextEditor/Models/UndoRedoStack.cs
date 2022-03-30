using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor.Operations
{
    public class UndoRedoStack : IStateManager
    {
        private Stack<IOperation> _Undo = new Stack<IOperation>(); 
        private Stack<IOperation> _Redo = new Stack<IOperation>();
        private IOperation _Operation;
        public UndoRedoStack()
        {
            Reset();
        }
        public void Reset()
        {
            _Undo.Clear();
            _Redo.Clear();
        }

        public IOperation Do(IOperation cmd)
        {
            _Undo.Push(cmd);
            _Redo.Clear();
            return cmd;// Anytime we push a new command, the redo stack clears
        }
        public IOperation Undo()
        {
            if (_Undo.Count > 0)
            {
                this._Operation = _Undo.Peek();
                _Undo.Pop();
                _Redo.Push(_Operation);
                return _Operation;
            }
            else
            {
                return null;
            }
        }
        public IOperation Redo()
        {
            if (_Redo.Count > 0)
            {
                this._Operation = _Redo.Peek();
                _Redo.Pop();
                _Undo.Push(_Operation);
                return _Operation;
            }
            else
            {
                return null;
            }
        }

    }
}
