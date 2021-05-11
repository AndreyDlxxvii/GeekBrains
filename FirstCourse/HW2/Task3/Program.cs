using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел
        
        //Худоерко Андрей
        static void Main(string[] args)
        {
            int i = 0;
            List<int> numberList = new List<int>();
            Console.WriteLine("Вводите числа");
            Console.WriteLine($"Сумма введенных чисел равно {Sum(numberList)}");
        }

        private static int Sum(List<int> numberList)
        {
            int i;
            do
            {
                i = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    numberList.Add(i);
                }
            } while (i != 0);

            int sum = numberList.Sum();
            return sum;
        }
    }
}