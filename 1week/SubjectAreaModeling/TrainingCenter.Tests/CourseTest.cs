using Xunit;
using TrainingCenter.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace TrainingCenter.Tests
{
    public class CourseTest
    {
        [Fact]
        public void FinalMark_TwoMarksOfOneLesson_ReturnTheFinalMarkOfCourse()
        {
            //arrange
            var Course = new Course();
            Course.Name = "Math";
            Student student = new Student();
            student.Courses.Add(student,Course);

            Lesson lesson = new Lesson();
            StudentAndLesson lessonAndLesson = new StudentAndLesson();
            StudentAndLesson lessonAndLesson2 = new StudentAndLesson();
            lessonAndLesson.Student = student;
            lessonAndLesson.Lesson = lesson;
            lessonAndLesson.Mark = 5;
            lessonAndLesson2.Student = student;
            lessonAndLesson2.Lesson = lesson;
            lessonAndLesson2.Mark = 2;
            List<StudentAndLesson> list = new List<StudentAndLesson>();
            list.Add(lessonAndLesson);
            list.Add(lessonAndLesson2);

            double expectedResult = 3.5;
            //act
            
            Course.PutAFinalMark(list, student);

            //assert

            Assert.Equal(expectedResult, Course.FinalMarks[student]);
        }
        [Fact]
        public void FinalMark_GivingAsAParamaterANull_ThrowArgumentNullException()
        {
            //arrange
            var Course = new Course();
            Course.Name = "Math";
            Student student = new Student();
            //act

            
            Action testCode = () => Course.PutAFinalMark(null, student);
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}