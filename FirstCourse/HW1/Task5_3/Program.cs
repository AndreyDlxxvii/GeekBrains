using System;

namespace Task5_3
{
    class Program
    {
        //Написать программу, которая выводит на экран ваше имя, фамилию и город проживания по середине экрана
        //с использованием собственных методов (например, Print(string ms, int x,int y)
        //Худоерко Андрей
        static void Main(string[] args)
        {
            string ms = "Андрей Худоерко г. Орел";
            Print(ms, Console.WindowWidth-ms.Length, Console.WindowHeight);
            Console.ReadKey();
        }

        private static void Print(string ms, int x, int y)
        {
            Console.SetCursorPosition(x / 2, y / 2);
            Console.Write(ms);
        }
    }
}