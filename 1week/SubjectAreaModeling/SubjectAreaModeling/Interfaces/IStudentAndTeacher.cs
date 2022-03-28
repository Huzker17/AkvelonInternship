using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Models;

namespace TrainingCenter.Interfaces
{
    public interface IStudentAndTeacher
    {
        public StudentAndTeacher Create(Student student,Teacher teacher);
    }
}
