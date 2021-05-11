using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{
    class Student
    {
        public string LastName;
        public string FirstName;
        public string University;
        public string Faculty;
        public int Course;
        public string Department;
        public int Group;
        public string City;
        public int Age;
        public Student(string firstName, string lastName, string university, string faculty, string department, int age,int course, int group, string city)
        {
            LastName = lastName;
            FirstName = firstName;
            University = university;
            Faculty = faculty;
            Department = department;
            Course = course;
            Age = age;
            Group = group;
            City = city;
        }
        public static int MyDelegat(Student st1, Student st2)          // Создаем метод для сравнения экземпляров
        {
            var u =String.Compare(st1.FirstName, st2.FirstName);
            return u; // Сравниваем две строки
        }

        public static List<Student> StudentList()// Создаем список студентов
        {

            List<Student> list = new List<Student>();                             
            StreamReader sr = new StreamReader(@"..\..\student.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0],s[1],s[2],s[3],s[4],int.Parse(s[5]),int.Parse(s[6]),int.Parse(s[7]),s[8]));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(Student.MyDelegat));
            return list;
        }

        public static (int bakalavr, int magistr) BakalavrMagistr(List<Student> std) // Переделанный метод возврата количества бакалавров и магистров
        {
            int bakalavr = 0;
            int magistr  = 0;
            foreach (var ell in std)
            {
                if (ell.Course<5)
                {
                    bakalavr++;
                }
                else
                {
                    magistr++;
                }
            }
            return (bakalavr, magistr);
        }

        public static int StudentFrom(int course)//Количество студентов опредленного курса с возможностью выбора
        {
            int i = 0;
            foreach (var ell in StudentList())
            {
                if (ell.Course == course)
                {
                    i++;
                }
            }
            return i;
        }

        public static (int student, string [] faculty) AgeStudentAndCourse(List<Student> std) // Возврат количества студентов от 18-20 лет и на каком курсе
        {
            int students = 0;
            int i=0;
            foreach (var ell in std)
            {
                if (ell.Age>=18 && ell.Age<=20)
                {
                    students++;
                }
            }

            string[] faculty = new string [students];
            foreach (var ell in std)
            {
                if (ell.Age>=18 && ell.Age<=20)
                {
                    faculty[i] = ell.Faculty;
                    i++;
                }
            }

            return (students, faculty);
        }

        public static IOrderedEnumerable<Student> SortByCourseAndAge(List<Student> std)// Сортировка по курсу и возрасту
        {
            var q = std.OrderBy(student => student.Course).ThenBy(student => student.Age);
            return q;
        }
    }
}