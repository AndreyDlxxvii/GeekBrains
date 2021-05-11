using System;

namespace Task1
{
    class Program
    {
        // Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).
        // В результате вся информация выводится в одну строчку:
        // а) используя  склеивание;
        // б) используя форматированный вывод;
        // в) используя вывод со знаком $.
        // Худоерко Андрей
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            string firstName = Console.ReadLine();
            
            Console.WriteLine("Введите фамилию");
            string secondName = Console.ReadLine();
            
            Console.WriteLine("Введите возраст");
            string agePerson = Console.ReadLine();
            
            Console.WriteLine("Введите рост");
            string heightPerson = Console.ReadLine();
            
            Console.WriteLine("Введите вес");
            string weightPerson = Console.ReadLine();
            
            Console.WriteLine("Имя: " + firstName + " Фамилия: " + secondName + " Возраст: " + agePerson + " Рост: " + heightPerson + " Вес: " + weightPerson);
            
            Console.WriteLine("Имя: {0} Фамилия: {1} Возраст: {2} Рост: {3} Вес: {4}", firstName, secondName, agePerson, heightPerson, weightPerson );
            
            Console.WriteLine($"Имя: {firstName} Фамилия: {secondName} Возраст: {agePerson} Рост: {heightPerson} Вес: {weightPerson}");
            
            Console.ReadKey();
        }
    }
}