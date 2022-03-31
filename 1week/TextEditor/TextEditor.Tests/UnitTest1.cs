using Moq;
using TextEditor.Interfaces;
using TextEditor.Models;
using TextEditor.Operations;
using Xunit;

namespace TextEditor.Tests
{
    public class MoveCursorOperation
    {
        [Fact]
        public void Move_Into_Existing_Row_And_Column()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            int row = 0;
            int column = 2;
            //act
            Invoker.MoveCursorTo(0,2);


            //asert

        }
    }
}