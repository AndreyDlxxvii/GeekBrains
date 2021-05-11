using System;

namespace Task2
{
    class Program
    {
        // Ввести вес и рост человека.
        // Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        // Худоерко Андрей
        static void Main(string[] args)
        {
            Console.WriteLine("Введите рост");
            double heightPerson = double.Parse(Console.ReadLine());
            heightPerson /=100;
            
            Console.WriteLine("Введите вес");
            double weightPerson = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"Индекс массы тела равен: {(weightPerson/(Math.Pow(heightPerson,2))):f2}");
            
            Console.ReadLine();

        }
    }
}