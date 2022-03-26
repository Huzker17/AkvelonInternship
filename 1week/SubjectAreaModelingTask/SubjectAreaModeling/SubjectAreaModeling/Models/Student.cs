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
        public IEnumerable<ILesson>? Lessons { get; set; }
        public int Mark { get; set; }
        public decimal AverageMark { get; set; }

        public int GetMark(ILesson lesson)
        {
            return lesson.GetMark(5);
        }
    }
}
