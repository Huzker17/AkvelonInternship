using System;
using System.Collections.ObjectModel;
using TrainingCenter.Interfaces;
using TrainingCenter.Models.BaseClass;

namespace TrainingCenter.Models
{
    public class Teacher : Person, ITeacher
    {
        public int Id { get; set; }
        public IDictionary<ITeacher, IStudent>? Students { get; set; }
        public ICollection<ICourse> Courses { get; set; } = new Collection<ICourse>();
        public ICollection<ILesson> Lessons { get; set; } = new Collection<ILesson>();
        public void PutMark(StudentAndLesson studentAndLesson, int mark)
        {
            if(studentAndLesson == null)
                throw new ArgumentNullException(nameof(studentAndLesson));
            if (!Lessons.Contains(studentAndLesson.Lesson))
                throw new Exception("This isn't this teacher's lesson");
            studentAndLesson.Mark = mark;
        }

    }
}
