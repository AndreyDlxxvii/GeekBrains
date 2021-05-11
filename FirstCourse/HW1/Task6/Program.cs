using System;

namespace Task6
{
    //Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause)
    //Андрей Худоерко
    class Student
    {
        public string firstName;
        public string secondName;
        public string city;
        public int age;
        public double weight;
        public double height;

        public void InfoAbout()
        {
            Console.WriteLine($"{firstName} {secondName} {city} {age}");
        }

        public void IMT()
        {
            height /= 100;
            Console.WriteLine($"Индекс массы тела равен: {(weight/(Math.Pow(height,2))):f2}");
        }

        public void Pause()
        {
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.age = 33;
            st.city = "Орел";
            st.height = 188;
            st.weight = 90;
            st.firstName = "Андрей";
            st.secondName = "Худоерко";
            st.InfoAbout();
            st.IMT();
            st.Pause();
        }
    }
}