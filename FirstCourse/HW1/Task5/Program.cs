using System;

namespace Task5
{
    class Program
    {
        //Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        //Андрей Худоерко
        static void Main(string[] args)
        {
            string firstName = "Андрей";
            string secondName = "Худоерко";
            string cityPerson = "Орел";
            
            Console.WriteLine($"{firstName} {secondName} из города {cityPerson}");
        }
    }
}