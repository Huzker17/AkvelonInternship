using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public decimal AverageMark { get; set; }
        public int GetMark(ILesson lesson)
        {
            return lesson.GetMark(5);
        }
        public ICollection<IStudentAndLessons>? StudentAndLessons { get; set; }
        public ICollection<IStudentAndCourses>? StudentAndCourses { get; set; }
        public ICollection<IStudentAndTeacher>? StudentAndTeachers { get; set; }
    }
}
