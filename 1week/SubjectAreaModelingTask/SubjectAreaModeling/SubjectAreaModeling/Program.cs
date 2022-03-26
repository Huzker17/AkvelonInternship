// See https://aka.ms/new-console-template for more information
using TrainingCenter.Models;

Console.WriteLine("Hello, World!");

Student student = new Student();
student.Mark = 5;
Lessons lessons = new Lessons();
List<Lessons> Lessons = new List<Lessons>();
Lessons.Add(lessons);
student.Lessons = Lessons;
student.GetMark(lessons);