using Xunit;
using TrainingCenter.Models;
using System;

namespace TrainingCenter.Tests
{
    public class TeacherTest
    {
        [Fact]
        public void PutAMark_ToCertain_StudentToCertainLesson_AMarkFieldEqualTo5()
        {
            //arrange
            Teacher Teacher = new Teacher();
            Student student = new Student();
            Lesson lesson = new Lesson();
            Teacher.Lessons.Add(lesson);
            StudentAndLesson studentAndLesson = new StudentAndLesson() { Lesson = lesson, Student = student};
            var expectedRes = 5;
            //act

            Teacher.PutMark(studentAndLesson, 5);

            //assert

            Assert.Equal(expectedRes, studentAndLesson.Mark);

        }
        [Fact]
        public void PutAMark_TeacherPutAMarkForDifferentLesson_ThrowException()
        {
            //arrange
            Teacher Teacher = new Teacher();
            Student student = new Student();
            Lesson lesson = new Lesson();
            StudentAndLesson studentAndLesson = new StudentAndLesson() { Lesson = lesson, Student = student };

            //act
            Action testCode = () => Teacher.PutMark(studentAndLesson,5);
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);
        }
        [Fact]
        public void PutAMark_OneParamterAsNUll_ThrowArgumentNullException()
        {
            //arrange
            Teacher Teacher = new Teacher();
 
            //act
            Action testCode = () => Teacher.PutMark(null,5);
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}