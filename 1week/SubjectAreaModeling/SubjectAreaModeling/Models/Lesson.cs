using System;
using System.Collections.Generic;
using System.Linq;
using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Lesson : ILesson
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public ICourse Course { get; set; }
        public int TeacherId { get; set; }
        public ITeacher Teacher { get; set; }
        public ICollection<IStudentAndLessons>? StudentAndLessons { get; set; }
        public int GetMark(int mark)
        {
            return mark;
        }
    }
}
