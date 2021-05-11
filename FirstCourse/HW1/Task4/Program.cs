using System;

namespace Task4
{
    class Program
    {
        // Написать программу обмена значениями двух переменных:
        // с использованием третьей переменной;
        // Худоерко Андрей

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            double a = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите второе число");
            double b = double.Parse(Console.ReadLine());
            
            var c = a;
            a = b;
            b = c;
            Console.WriteLine($"Первое число {a} второе число {b}");
            
            Console.ReadLine();
        }
    }
}