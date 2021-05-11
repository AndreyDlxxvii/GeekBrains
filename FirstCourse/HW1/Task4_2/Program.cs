using System;

namespace Task4_2
{
    class Program
    {
        // Написать программу обмена значениями двух переменных:
        // без использованием третьей переменной;
        // Худоерко Андрей
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            double a = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите второе число");
            double b = double.Parse(Console.ReadLine());
            
            a += b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Первое число {a} второе число {b}");
            
            Console.ReadLine();
        }
    }
}