using System;
using System.Collections.Generic;

namespace Task7_2
{
    class Program
    {
        // Разработать рекурсивный метод, который считает сумму чисел от a до b.
        
        // Худоерко Андрей
        

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число а");
            int a = 1;//int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число b");
            int b = 9;//int.Parse(Console.ReadLine());

           
            Console.WriteLine(SumAllNumbers(a,b));
        }

        private static int SumAllNumbers(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            return SumAllNumbers(a+1,b) + a;
        }
    }
}
