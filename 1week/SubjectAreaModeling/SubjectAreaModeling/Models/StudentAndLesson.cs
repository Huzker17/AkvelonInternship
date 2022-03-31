using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class StudentAndLesson : IStudentAndLessons
    {
        public int Id { get; set; }
        public IStudent Student { get; set; }
        public int StudentId { get; set; }
        public ILesson Lesson { get; set; }
        public int LessonId { get; set; }
        public int Mark { get; set; }
    }
}
