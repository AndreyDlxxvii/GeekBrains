using System;
using System.Runtime.InteropServices;

namespace Task5
{
    // Написать программу, которая запрашивает массу и рост человека, 
    // вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме
    
    //Худоерко Андрей
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите рост");
            double heightPerson = double.Parse(Console.ReadLine());
            heightPerson /=100;
            
            Console.WriteLine("Введите вес");
            double weightPerson = double.Parse(Console.ReadLine());
            
            //Console.WriteLine($"Индекс массы тела равен: {(weightPerson/(Math.Pow(heightPerson,2))):f2}");
            CheckIMT((weightPerson/(Math.Pow(heightPerson,2))));
        }

        private static void CheckIMT(double imt)
        {
            if (imt <= 16)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Выраженный дефицит массы тела");
            }
            else if (imt > 16 && imt <= 18.5)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Недостаточная (дефицит) масса тела");
            }
            else if (imt > 18.5 && imt <= 25)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Норма");
            }
            else if (imt > 25 && imt <= 30)
            {
                Console.WriteLine($"ИМТ: {imt:f2}Избыточная масса тела (предожирение){imt:f2}");
            }
            else if (imt > 30 && imt <= 35)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Ожирение");
            }
            else if (imt > 35 && imt <= 40)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Ожирение резкое");
            }
            else if (imt > 40)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Очень резкое ожирение");
            }

        }
    }
}