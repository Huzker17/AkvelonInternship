create database SubjectAreaModeling;

use SubjectAreaModeling;


create table Students
(
student_id int IDENTITY(1,1)   not null  primary key,
student_name VARCHAR(30)  not null,
final_score float,
);
create table Teachers
(
teacher_id int not null primary key,
teacher_name varchar(50) not null
);

create table Courses
(
course_id int IDENTITY(1,1) not null primary key,
course_name VARCHAR(50) not null,
teacher_id int not null,
CONSTRAINT FK_teacher_id FOREIGN KEY (teacher_id) REFERENCES Teachers (teacher_id),
);

create table Lessons
(
lesson_id int IDENTITY(1,1) not null primary key,
lesson_name varchar(50) not null,
lesson_mark int ,
student_id int not null,
course_id int not null,
CONSTRAINT FK_Student_Id FOREIGN KEY(student_id)REFERENCES Students(student_id),
CONSTRAINT FK_course FOREIGN KEY (course_id) REFERENCES Courses (course_id)
);

create table Student_Course_junction
(
course_id int,
student_id int,
CONSTRAINT course_stud_pk PRIMARY KEY (course_id, student_id),
CONSTRAINT FK_course_ FOREIGN KEY (course_id) REFERENCES Courses(course_id),
CONSTRAINT FK_student_ FOREIGN KEY (student_id) REFERENCES Students(student_id)
);
create table Student_Teacher_junction
(
teacher_id int,
student_id int,
CONSTRAINT teacher_student_pk PRIMARY KEY (teacher_id, student_id),
CONSTRAINT FK_teacher FOREIGN KEY (teacher_id) REFERENCES Teachers(teacher_id),
CONSTRAINT FK_student FOREIGN KEY (student_id) REFERENCES Students(student_id)
);


insert into Teachers(teacher_id,teacher_name) values (1,'Rebecca'),(2,'Marshall'),(3,'Johnny');

insert into Courses(course_name,teacher_id) values
('Chemistry',1),('Math',2),('Biology',3),('Geometry',2);

insert into Students(student_name,final_score) values('Karl', 0);
insert into Students(student_name,final_score) values('Ben', 0);
insert into Students(student_name,final_score) values('Gwen', 0);
insert into Students(student_name,final_score) values('Amber', 0);
insert into Students(student_name,final_score) values('Doe', 0);

insert into Student_Teacher_junction(student_id, teacher_id) values(2,1),(2,2),(2,3),(3,1),(4,1);

select * from Students_Teachers_junction;

insert into Lessons(lesson_mark,lesson_name,student_id,course_id) values 
(5,'Algebra', 1,3),(3,'Algebra', 1,3),(4,'Algebra', 1,3),(4,'Algebra', 1,3),(3,'Algebra', 1,3);

insert into Lessons(lesson_mark,lesson_name,student_id,course_id) values 
(5,'Algebra', 2,3),(4,'Algebra', 2,3),(3,'Algebra', 2,3),(2,'Algebra', 2,3),(3,'Algebra', 2,3);

insert into Lessons(lesson_mark,lesson_name,student_id,course_id) values 
(5,'Chem', 2,2),(4,'Chem', 2,2),(3,'Chem', 2,2),(2,'Chem', 2,2),(3,'Chem', 2,2);

insert into Student_Course_junction(course_id,student_id)
values (1,2),(1,3),(1,4),(2,2),(2,3),(2,4),(3,2),(3,3),(3,4);

update Students 
	set final_score =(select (Sum(Lessons.lesson_mark)/COUNT(Lessons.lesson_mark)) from
						Lessons inner join Student_Course_junction as junc 
						on Students.student_id = junc.student_id
						where Students.student_id = junc.student_id
						and Lessons.course_id = junc.course_id);

select * from Students;
select * from Lessons;
select * from Student_Course_junction;




