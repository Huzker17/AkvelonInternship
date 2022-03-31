
using System.Collections.Generic;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public IDictionary<IStudent, ILesson> Lessons { get; set; } = new Dictionary<IStudent, ILesson>();
        public IDictionary<IStudent, ICourse> Courses { get; set; } = new Dictionary<IStudent, ICourse>();
        public IDictionary<IStudent, ITeacher> Teachers { get; set; } = new Dictionary<IStudent, ITeacher>();

        public bool TakeLesson(Lesson lesson)
        {
            if(lesson == null)
                throw new ArgumentNullException(nameof(lesson));
            if (lesson.GetType() == typeof(Lesson))
            {
                Lessons.Add(this, lesson);
                return true;
            }
            return false;
        }


    }
}
