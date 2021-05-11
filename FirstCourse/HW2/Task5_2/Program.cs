using System;
using System.Diagnostics;

namespace Task5_2
{

    class Program
    {
        // Написать программу, которая запрашивает массу и рост человека, 
        // вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме
        // Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса
        
        // Худоерко Андрей

        static double heightPerson;
        static double weightPerson;
        static double normalWeight;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите рост");
            heightPerson = double.Parse(Console.ReadLine());
            heightPerson /=100;
            
            Console.WriteLine("Введите вес");
            weightPerson = double.Parse(Console.ReadLine());
            
            CheckIMT((weightPerson/(Math.Pow(heightPerson,2))));
        }

        private static void CheckIMT(double imt)
        {
            if (imt <= 16)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Выраженный дефицит массы тела");
                normalWeight = weightPerson - Math.Pow(heightPerson,2)*25;
            }
            else if (imt > 16 && imt <= 18.5)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Недостаточная (дефицит) масса тела");
                normalWeight = weightPerson - Math.Pow(heightPerson,2)*25;
            }
            else if (imt > 18.5 && imt <= 25)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Норма");
            }
            else if (imt > 25 && imt <= 30)
            {
                normalWeight = weightPerson - (Math.Pow(heightPerson,2)*25);
                Console.WriteLine($"ИМТ: {imt:f2} Избыточная масса тела (предожирение)");
            }
            else if (imt > 30 && imt <= 35)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Ожирение");
                normalWeight = weightPerson - Math.Pow(heightPerson,2)*25;
            }
            else if (imt > 35 && imt <= 40)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Ожирение резкое");
                normalWeight = weightPerson - Math.Pow(heightPerson,2)*25;
            }
            else if (imt > 40)
            {
                Console.WriteLine($"ИМТ: {imt:f2} Очень резкое ожирение");
                normalWeight = weightPerson - Math.Pow(heightPerson,2)*25;
            }

            if (normalWeight > 0)
            {
                Console.WriteLine($"Для достижения нормального веса необходимо похудеть на {normalWeight:f2} кг");
            }
            else
            {
                Console.WriteLine($"Для достижения нормального веса необходимо набрать {Math.Abs(normalWeight):f2} кг");
            }

            // Console.WriteLine($"Изменить вес на {normalWeight:f2}");

        }
    }
    
}