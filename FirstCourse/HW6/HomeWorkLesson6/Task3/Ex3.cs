using System;

namespace Task3
{
    internal class Ex3
    {
        public static void Start()
        {
            Console.WriteLine("Всего студентов:" + Student.StudentList().Count);
            Console.WriteLine("Магистров:{0}", Student.BakalavrMagistr(Student.StudentList()).magistr);
            Console.WriteLine("Бакалавров:{0}", Student.BakalavrMagistr(Student.StudentList()).bakalavr);
            //foreach (var v in Student.StudentList()) Console.WriteLine(v.FirstName);
            Console.WriteLine($"Введите курс чтобы узнать количество студентов");
            var i = int.Parse(Console.ReadLine());
            Console.WriteLine($"Студентов {i} курса - {Student.StudentFrom(i)}");
            Console.WriteLine($"Студентов от 18 до 20 лет - {Student.AgeStudentAndCourse(Student.StudentList()).student} " +
                              $"учатся на следующих курсах {string.Join(",", Student.AgeStudentAndCourse(Student.StudentList()).faculty)}");
            Console.WriteLine("Список отсортированный по курсу и возрасту");
            foreach (var ell in Student.SortByCourseAndAge(Student.StudentList()))Console.WriteLine($"Курс {ell.Course} лет {ell.Age}");
            Console.ReadKey();
        }
    }
}