// See https://aka.ms/new-console-template for more information
using TrainingCenter.Models;

Console.WriteLine("Hello, World!");

var Course = new Course();
Course.Name = "Math";
Student student = new Student();
student.Courses.Add(student, Course);
Lesson lesson = new Lesson();
StudentAndLesson lessonAndLesson = new StudentAndLesson();
StudentAndLesson lessonAndLesson2 = new StudentAndLesson();
lessonAndLesson.Student = student;
lessonAndLesson.Lesson = lesson;
lessonAndLesson.Mark = 5;
lessonAndLesson2.Student = student;
lessonAndLesson2.Lesson = lesson;
lessonAndLesson2.Mark = 2;
List<StudentAndLesson> list = new List<StudentAndLesson>();
//list.Add(lessonAndLesson);
//list.Add(lessonAndLesson2);

double expectedResult = 3;
//act

Course.PutAFinalMark(list, student);


