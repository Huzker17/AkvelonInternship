using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class StudentAndTeacher : IStudentAndTeacher
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public IStudent? Student { get; set; }
        public int TeacherId { get; set; }
        public ITeacher? Teacher { get; set; }

        public StudentAndTeacher Create(Student student, Teacher teacher)
        {
            if(student == null)
                throw new ArgumentNullException(nameof(student));
            if(teacher == null)
                throw new ArgumentNullException(nameof(teacher));
            this.Teacher = teacher;
            this.Student = student;
            this.TeacherId = teacher.Id;
            this.StudentId = student.Id;
            return this;
        }
    }
}
