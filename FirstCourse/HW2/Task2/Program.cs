using System;

namespace Task2
{
    class Program
    {
        //Написать метод подсчета количества цифр числа
        
        //Андрей Худоерко
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            string number = Console.ReadLine();
            Console.WriteLine($"Количество цифр {CountOfNumber(number)}");
        }

        private static int CountOfNumber(string number)
        {
            int countOfNumber = number.Length;
            return countOfNumber;
        }
    }
}