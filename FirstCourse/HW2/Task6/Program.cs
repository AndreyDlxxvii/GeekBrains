using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Task6
{
    // Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
    // «Хорошим» называется число, которое делится на сумму своих цифр. 
    // Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
    
    // Худоерко Андрей
    class Program
    {
        //С циклом 2:01
        static void Main(string[] args)
        {
            int j = 0;
            var start = DateTime.Now;
            for (int i = 1; i <= 1000000000; i++)
            {
                int sum = 0;
                var temp = i;
                while (i>0)
                {
                    sum += i % 10;
                    i /= 10;
                }
                if (temp % sum == 0)
                {
                    j++;
                }
                i = temp;
            }
     
            
            Console.WriteLine($"Продожительность програмы {DateTime.Now-start}");
            Console.WriteLine($"Число хороших чисел {j}");
        }
        // С костылями 17 минут)
        //        static void Main(string[] args)
        //{
        // int q = 0;
        // var start = DateTime.Now;
        // List<int> number = new List<int>();
        // for (int i = 1; i <= 1000000000; i++)
        // {
        //     number.Clear();
        //     for (int j = 0; j < i.ToString().Length; j++)
        //     {
        //         var temp = i.ToString().ToCharArray();
        //         number.Add(int.Parse(temp[j].ToString()));
        //     }
        //     var r = number.Sum();
        //     if (i % r == 0)
        //     {
        //         //Console.WriteLine($"{i} - Хрошее число");
        //         q++;
        //     }
        // }
        //
        // var finish = DateTime.Now;
        // Console.WriteLine($"{finish-start}");
        // Console.WriteLine(q);
        //}
    }
}