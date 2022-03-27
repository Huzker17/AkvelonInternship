using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class StudentAndLessons: IStudentAndLessons
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public IStudent Student { get; set; }
        public int LessonId { get; set; }
        public ILesson Lesson { get; set; }
    }
}
