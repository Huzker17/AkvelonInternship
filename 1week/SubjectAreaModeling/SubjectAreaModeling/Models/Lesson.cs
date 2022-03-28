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
        public ICollection<IStudentAndLessons>? StudentAndLessons { get; set; }
        public ICollection<IStudentAndLessons>? Marks { get; set; }

        public void Create(Course course)
        {
            if(course == null)
                throw new ArgumentNullException(nameof(course));
            this.Course = course;
            this.CourseId = course.Id;
            this.Teacher = course.Teacher;
            this.TeacherId = course.TeacherId;
        }
    }
}
