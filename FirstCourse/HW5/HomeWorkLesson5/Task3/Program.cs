using System;

namespace Task3
{
    // Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    // Например:
    // badc являются перестановкой abcd
    // Худоерко Андрей
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово");
            string word1 = Console.ReadLine();
            Console.WriteLine("Введите слово");
            string word2 = Console.ReadLine();
            CheckTwoWords.Check(word1,word2);
        }
    }
}