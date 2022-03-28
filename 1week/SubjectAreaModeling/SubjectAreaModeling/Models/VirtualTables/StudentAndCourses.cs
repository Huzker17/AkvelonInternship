using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCenter.Interfaces;
using TrainingCenter.Models.VirtualTables;

namespace TrainingCenter.Models
{
    public class StudentAndCourses : IStudentAndCourses
    {
        /// <summary>
        /// Id of Virtual Table
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id of Certain Student
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Certain Student Instance
        /// </summary>
        public IStudent? Student { get; set; }
        /// <summary>
        /// Id of Certain Course
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// Instance of certain Course
        /// </summary>
        public ICourse? Course { get; set; }
        /// <summary>
        /// Double Field for FinalScore for Certain Student of Certain Course
        /// </summary>
        public double FinalScore { get; set; }
        /// <summary>
        /// The realization of Implemented Method
        /// </summary>
        /// <param name="studentAndLessons">Collection of lessons and marks</param>
        /// <returns>The average Score for Whole Course</returns>
        /// <exception cref="NotImplementedException"></exception>
        public double FinalMark(ICollection<StudentAndLesson> studentAndLessons)
        {
            if(studentAndLessons == null)
                 throw new ArgumentNullException(nameof(studentAndLessons));
            if(studentAndLessons.Count == 0)
                return 0;
            //The best one will something like
            //We got as params just a Id Of student
            //var studentAndLessons = _db.StudentsAndLessons.Where(x.StudentId == studentId).ToList();
            int Marks = 0;
            foreach (var lesson in studentAndLessons)
            {
                Marks += lesson.Mark;
            }
            return Marks/studentAndLessons.Count();
        }
    }
}
