using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task5
{
    public class Student
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

        public Student()
        {
            
        }
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

        public override string ToString()
        {
            return $"{FirstName} {LastName} {University} {Faculty} {Course} {Department} {Group} {City} {Age}";
        }
        // public static List<Student> StudentList()
        // {
        //     List<Student> list = new List<Student>();
        //     return list;
        // }

        
    }
    public class Transformer
    {
        public static List<Student> ReadFromCsv(string path)
        {
            List<Student> list = new List<Student>();
            string i;
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                try
                {
                    string[] s = reader.ReadLine()?.Split(';');
                    list.Add(new Student(s[0],s[1],s[2],s[3],s[4],int.Parse(s[5]),int.Parse(s[6]),int.Parse(s[7]),s[8]));
                }
                catch(Exception e)
                {
                    MessageBox.Show("Ошибка чтения файла");
                }
            }
            reader.Close();
            return list;
        }

        public static void WriteToXml (List<Student> std, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            FileStream str = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(str,std);
            str.Close();

        }
    }
}