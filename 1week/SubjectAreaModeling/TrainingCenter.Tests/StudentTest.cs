using System;
using TrainingCenter.Models;
using Xunit;

namespace TrainingCenter.Tests
{
    public class StudentTest
    {
        [Fact]
        public void Taking_Lesson_As_A_Student()
        {
            //arrange
            var student = new Student();
            var lesson = new Lesson();

            //act
            var expectedRes = student.TakeLesson(lesson);

            //assert
            Assert.True(expectedRes);
        }
        [Fact]
        public void Taking_Null_As_A_Parameter()
        {
            //arrange
            var student = new Student();
            Action testCode = () => student.TakeLesson(null);
            //act
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}