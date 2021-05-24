using System;
using System.Linq;
using System.Collections.Generic;
namespace Classwork1
{

    class Student
    {

        public string Name { get; internal set; }

        public string UniversityName { get; internal set; }

    }

    class Teacher
    {
        public string Name { get; internal set; }

        public string UniversityName { get; internal set; }
    }

    class University
    {
        public string Name { get; internal set; }

        public int StudentCount { get; internal set; }

        public int TeacherCount { get; internal set; }
    }

    class Program {
        static void Main(string[] args)
        {
            Student[] students = new Student[] {
                new Student { Name = "Bogdan", UniversityName = "HSE"}, new Student {Name = "Anton", UniversityName = "MIPT" },
                new Student { Name = "Vlad", UniversityName = "HSE"}, new Student {Name = "Dmitry", UniversityName = "MIPT"}};
            Teacher[] teachers = new Teacher[] {
                new Teacher { Name = "Ilya", UniversityName = "HSE"}, new Teacher {Name = "Pavel", UniversityName = "MIPT" },
                new Teacher { Name = "Olga", UniversityName = "HSE"}, new Teacher {Name = "Gregory", UniversityName = "MIPT"}};

            University[] universities = new University[] { new University { Name = "HSE", StudentCount = 2, TeacherCount = 2}, new University { Name = "MIPT", StudentCount = 2, TeacherCount = 2}, new University { Name = "MSU" } };

            // 1.
            var firstQuery = from Student student in students
                             orderby student.Name
                             group student by student.UniversityName;
                             
            foreach (IGrouping<string, Student> element in firstQuery) { Console.WriteLine($"{element.Key}: "); foreach (Student student in element) { Console.WriteLine(student.Name); } }
            Console.WriteLine();
            // 2.
            var secondQuery = from Teacher teacher in teachers
                             orderby teacher.Name
                             group teacher by teacher.UniversityName;

            foreach (IGrouping<string, Teacher> element in firstQuery) { Console.WriteLine($"{element.Key}: "); foreach (Teacher teacher in element) { Console.WriteLine(teacher.Name); } }
            Console.WriteLine();
            // 3.
            var thirdQuery = students.Join(universities, student => student.UniversityName, univ => univ.Name, (student, univ) => (student.Name, univ.Name)).OrderBy(pair => pair.Item2);
            foreach (var pair in thirdQuery) { Console.WriteLine($"{pair.Item1} {pair.Item2}"); }
            // 4.
            var fourthQuery = teachers.Join(universities, teacher => teacher.UniversityName, univ => univ.Name, (teacher, univ) => (teacher.Name, univ.Name)).OrderBy(pair => pair.Item2);
            foreach (var pair in fourthQuery) { Console.WriteLine($"{pair.Item1} {pair.Item2}"); }
            // 5.
            //var fifthQuery = 
            
            // 6.
            var sixthQuery = universities.GroupJoin(teachers, university => university.Name, teacher => teacher.UniversityName, (univ, teacherList) => teacherList.Select(teacher => (univ, teacher)));
           // foreach ()
            // 7.
            var seventhQuery = teachers.Zip(students, (element1, element2) => (element1, element2));
            foreach ((Teacher, Student) tuple in seventhQuery) { Console.WriteLine($"{tuple.Item1.Name} - {tuple.Item2.Name}"); }
        }

    }
}


/* Создать классы:
Студент (имя, университет - строка название)
Преподаватель (имя, университет - строка название)
Университет (название, численность студентов, численность преподавателей)



В основной программе заполнить три списка элементов из студентов, преподавателей, университетов и написать и выполнить запросы:
1) Сгруппировать студентов по университетам и отсортировать по университету лексикографически
2) Сгруппировать преподавателей по университетам и отсортировать по университету лексикографически
3) Соединить студентов с университетами (join), вывести информацию о студенте и университете (название, численность студентов) и отсортировать по университету лексикографически
4) Соединить преподавателей с университетами (join), вывести информацию о преподавателе и университете (название, численность студентов) и отсортировать по университету лексикографически
5) Соединить студентов с университетами и выполнить группировку по университетам (group join), вывести информацию о студенте и университете (название, численность студентов)
6) Соединить преподавателей с университетами и выполнить группировку по университетам (group join), вывести информацию о преподавателе и университете (название, численность студентов)
7) Соединить каждого преподавателя с каждым студентом (zip)

*/