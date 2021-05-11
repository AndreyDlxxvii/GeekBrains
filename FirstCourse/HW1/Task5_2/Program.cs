using System;

namespace Task5_2
{
    class Program
    {
        //Написать программу, которая выводит на экран ваше имя, фамилию и город проживания по центру экрана
        //Андрей Худоерко
        static void Main(string[] args)
        {
            string ms = "Андрей Худоерко г.Орел";
            
            Console.SetCursorPosition((Console.WindowWidth-ms.Length)/2, Console.WindowHeight/2);
            Console.Write(ms);
            
            Console.ReadKey();
        }
    }
}