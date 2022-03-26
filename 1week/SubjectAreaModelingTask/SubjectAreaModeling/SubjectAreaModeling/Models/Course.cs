using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Course : ICourse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<ILesson>? Lessons { get; set; }

    }
}
