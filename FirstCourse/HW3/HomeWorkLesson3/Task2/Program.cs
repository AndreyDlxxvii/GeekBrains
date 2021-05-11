using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    // С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке) используя tryParse. 
    // Требуется подсчитать сумму всех нечётных положительных чисел. Сами числа и сумму вывести на экран.
    // Худоерко Андрей
    class Program
    {
        static void Main(string[] args)
        {
            double i = 0;
            List<double> numList = new List<double>();
            Console.WriteLine("Вводите числа");
            do
            {
                if (double.TryParse(Console.ReadLine(), out i) && i%2!=0 && i>0)
                {
                    numList.Add(i);
                    Console.WriteLine($"Принятое число {i}");
                }
            } while (i!=0);
            Console.WriteLine($"Сумма всех принятых чисел {numList.Sum()}");
        }
    }
}