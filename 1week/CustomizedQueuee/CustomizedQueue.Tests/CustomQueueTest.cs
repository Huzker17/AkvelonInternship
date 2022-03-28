using CustomizedQueuee;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomizedQueue
{
    public class CustomQueueTest
    {
        [Fact]
        public void Enqueue_String_Into_QueueString()
        {
            //arrange
            var queue = new CustomQueue();
            var AddedItem = "Item";

            //act
            queue.Enqueue(AddedItem);
            var result = queue.Peak();

            //assert
            Assert.Equal(AddedItem, result);
        }
        [Fact]
        public void Dequeue_String_From_QueueString()
        {
            //arrange
            var queue = new CustomQueue();
            var AddedItem = "Item";
            queue.Enqueue(AddedItem);
            var secondItem = "Item2";
            queue.Enqueue(secondItem);

            //act
            queue.Dequeue();
            var result = queue.Peak();

            //assert
            Assert.Equal(result,secondItem);
        }
        [Fact]
        public void Taking_A_Peak_From_CustomQueue()
        {
            //arrange
            var queue = new CustomQueue();
            var AddedItem = "Item";
            queue.Enqueue(AddedItem);
            var secondItem = "Item2";
            queue.Enqueue(secondItem);

            //act
            var result = queue.Peak();

            //assert
            Assert.Equal(result,AddedItem);
        }
        [Fact]
        public void Get_ArgumentException_When_Queue_Type_And_Adding_Item_Not_Same()
        {
            //arrange
            var queue = new CustomQueue();
            queue.Enqueue(12);
            Action testCode = () => queue.Enqueue("string");
            //act
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);

        }
        [Fact]
        public void Get_InvalidOperationException_When_Try_To_Delete_From_Empty_Queue()
        {
            //arrange
            var queue = new CustomQueue();
            Action testCode = () => queue.Dequeue();
            //act
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);

        }
    }
}