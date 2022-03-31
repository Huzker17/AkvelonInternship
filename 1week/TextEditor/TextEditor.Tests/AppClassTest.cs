using Moq;
using System;
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
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');
            int row = 0;
            int column = 2;

            //act
            Invoker.MoveCursorTo(row,column);
            int TextRow = 0;
            int TextColumn = 2;


            //asert
            Assert.Equal(TextRow, Text.Row);
            Assert.Equal(TextColumn, Text.Column);

        }
        [Fact]
        public void InsertCharTo_AddCharToText_AndGotIncreasingColumn()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);


            //act
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');


            //asert
            Assert.Equal(4, Text.Column);

        }    
        [Fact]
        public void DeleteChar_DeletingCharFromText_GetDecreasingIndexOfColumn()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');


            //act
            Invoker.Delete();

            //asert
            Assert.Equal(3, Text.Column);
        }
        [Fact]
        public void MoveCursor_MoveCursorToUnexsitingIndexes_ThrowArgumentOutOfRangeException()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');
            Action testCode = () => Invoker.MoveCursorTo(10,10);
            //act
            var ex = Record.Exception(testCode);
            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }
        [Fact]
        public void Undo_UndoingInsertingChar_IncreasingOfColumnIndex()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');
            int expectedColumnIndex = 3;
            //act

            Invoker.Undo();
            //asert

            Assert.Equal(expectedColumnIndex, Text.Column);
        }
        [Fact]
        public void Undo_UndoingDeletingChar_GetThePreviousAmountOfColumnIndex()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');
            Invoker.Delete();
            int expectedColumnIndex = 4;
            //act
            
            Invoker.Undo();
            //asert

            Assert.Equal(expectedColumnIndex, Text.Column);
        }
        [Fact]
        public void CreateARow_CreatingARowInText_GetIncreasedAmountOfRow()
        {
            //arrange
            var Text = new TextClass();
            var stateManager = new UndoRedoStack();
            var Invoker = new App(Text, stateManager);
            Invoker.InsertChar('H');
            Invoker.InsertChar('E');
            Invoker.InsertChar('L');
            Invoker.InsertChar('L');
            int expectedRowIndex = 1;
            //act
            Invoker.CreateANewRow();
            //asert

            Assert.Equal(expectedRowIndex, Text.Row);
        }
    }
}