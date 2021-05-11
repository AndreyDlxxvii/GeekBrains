using System;
using System.Collections.Generic;

namespace Task7
{
    class Program
    {
        // Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        
        // Худоерко Андрей

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число а");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число b");
            int b = int.Parse(Console.ReadLine());
         
             PrintNumbersOnRank(a, b);
        }

        private static void PrintNumbersOnRank(int  a, int b)
        {
            Console.WriteLine(a);
            if (a<b)
            {
                PrintNumbersOnRank(a+1,b);
            }
        }
    }
}