using System;
using TrainingCenter.Interfaces;
using TrainingCenter.Models.BaseClass;

namespace TrainingCenter.Models
{
    public class Teacher : Person, ITeacher
    {
        public int Id { get; set; }
        public ICollection<IStudentAndTeacher>? StudentAndTeachers { get; set; }
        public ICollection<ICourse>? Courses { get; set; }
        public ICollection<ILesson>? Lesson { get; set; }

    }
}
