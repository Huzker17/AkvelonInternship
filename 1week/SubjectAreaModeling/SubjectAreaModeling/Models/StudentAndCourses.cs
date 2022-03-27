using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class StudentAndCourses : IStudentAndCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public IStudent Student { get; set; }
        public int CourseId { get; set; }
        public ICourse Course { get; set; }
    }
}
