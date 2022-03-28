
using TrainingCenter.Interfaces;
using TrainingCenter.Models.VirtualTables;

namespace TrainingCenter.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public double AverageMarkScore { get; set; }
        public ICollection<IStudentAndLessons> StudentAndLessons { get; set; }
        public ICollection<IStudentAndCourses> StudentAndCourses { get; set; }
        public ICollection<IStudentAndTeacher> StudentAndTeachers { get; set; }

        public bool TakeLesson(Lesson lesson)
        {
            if(lesson == null)
                throw new ArgumentNullException(nameof(lesson));
            var StudentAndLesson = new StudentAndLesson();
            StudentAndLesson.Student = this;
            StudentAndLesson.Lesson = lesson;
            if (lesson.GetType() == typeof(Lesson))
            {
                this.StudentAndLessons.Add(StudentAndLesson);
                return true;
            }
            return false;
        }
    }
}
