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
        public IDictionary<ICourse, IStudent>? Students { get; set; }
        public IDictionary<IStudent, double> FinalMarks { get; set; } = new Dictionary<IStudent, double>();

        public void Create(int TeacherId, string Name)
        {
            if(TeacherId < 0)
                    throw new ArgumentOutOfRangeException(nameof(TeacherId));
            Course course1 = new Course();
            course1.TeacherId = TeacherId;
            course1.Name = Name;
        }
        private double CountFinalMark(ICollection<StudentAndLesson> marks)
        {

            double count = 0;
            foreach (var item in marks)
            {
                count += (double)item.Mark;
            }
            count = count / marks.Count();
            return count;
        }
        public void PutAFinalMark(ICollection<StudentAndLesson> marks , IStudent student)
        {
            if(marks == null || student == null)
                throw new ArgumentNullException("One of the paramaters is null");
            double AverageMark = this.CountFinalMark(marks);
            this.FinalMarks.Add(student, AverageMark);
        }
    }
}
