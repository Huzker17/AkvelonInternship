using TrainingCenter.Interfaces;

namespace TrainingCenter.Models
{
    public class Course : ICourse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeacherId { get; set; }
        public ITeacher? Teacher { get; set; }
        public ICollection<ILesson>? Lessons { get; set; }
        public ICollection<IStudentAndCourses>? StudentAndCourses { get; set; }

        public void Create(int TeacherId, string Name)
        {
            if(TeacherId < 0)
                    throw new ArgumentOutOfRangeException(nameof(TeacherId));
            Course course1 = new Course();
            course1.TeacherId = TeacherId;
            course1.Name = Name;
        }
    }
}
