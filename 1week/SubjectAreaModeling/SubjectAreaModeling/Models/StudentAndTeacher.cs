using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.Models
{
    public class StudentAndTeacher : IStudentAndTeacher
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public IStudent Student { get; set; }
        public int TeacherId { get; set; }
        public ITeacher Teacher { get; set; }
    }
}
