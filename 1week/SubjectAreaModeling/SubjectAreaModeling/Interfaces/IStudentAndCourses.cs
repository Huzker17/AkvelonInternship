using System;

using TrainingCenter.Interfaces;
using TrainingCenter.Models.VirtualTables;

namespace TrainingCenter.Models
{
    public interface IStudentAndCourses
    {
        /// <summary>
        /// Method for counting final results of Student for Certain Course
        /// </summary>
        /// <param name="studentAndLessons">Getting all lessons with marks from DB :)</param>
        /// <returns>The counted average points</returns>
       public double FinalMark(ICollection<StudentAndLesson> studentAndLessons);
    }
}
