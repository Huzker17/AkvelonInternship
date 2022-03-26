using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;
using TrainingCenter.Models.BaseClass;

namespace TrainingCenter.Models
{
    public class Teacher : Person, ITeacher
    {
        public int Id { get; set; }
        public ICollection<IStudent>? Students { get; set; }
        public ICollection<ICourse>? Courses { get; set; }

    }
}
