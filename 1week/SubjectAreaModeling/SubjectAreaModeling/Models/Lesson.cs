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
        public ICourse? Course { get; set; }
        public int TeacherId { get; set; }
        public ITeacher? Teacher { get; set; }
        public IDictionary<ILesson, IStudent> Students { get; set; }
        public ICollection<IStudentAndLessons>? Marks { get; set; }

    }
}
