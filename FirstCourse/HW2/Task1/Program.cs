using System;

namespace Task1
{
    //Написать метод, возвращающий минимальное из трёх чисел.
    
    //Худоерко Андрей
    class Program
    {
        static void Main(string[] args)
        {
            double min = 0;
            Console.WriteLine("Введите число а");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите число в");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите число с");
            double c = double.Parse(Console.ReadLine());
            min = a > b ? b : a;
            min = c > min ? min : c;
            Console.WriteLine($"Наименьшее число {min}");
        }
    }
}