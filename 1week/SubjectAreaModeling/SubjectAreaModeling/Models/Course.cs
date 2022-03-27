using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Course : ICourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public ITeacher Teacher { get; set; }
        public ICollection<ILesson>? Lessons { get; set; }
        public ICollection<IStudentAndCourses>? StudentAndCourses { get; set; }

    }
}
