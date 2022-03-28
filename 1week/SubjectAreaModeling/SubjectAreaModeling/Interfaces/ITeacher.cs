using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Models.VirtualTables;

namespace TrainingCenter.Interfaces
{
    public interface ITeacher
    {
        /// <summary>
        /// Method for put a mark to a certain student
        /// </summary>
        /// <param name="studentAndLesson">Virtual Table between Student and Lesson</param>
        /// <param name="mark">The Mark for certain Student and for Certain Lesson</param>
        public void PutMark(StudentAndLesson studentAndLesson, int mark);
    }
}
