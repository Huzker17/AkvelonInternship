using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Lessons : ILesson
    {
        public int GetMark(int mark)
        {
            return mark;
        }
    }
}
