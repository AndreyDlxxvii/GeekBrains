﻿using System;

namespace Task2
{
    // Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
    // а) Вывести только те слова сообщения,  которые содержат не более n букв.
    // б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    // в) Найти самое длинное слово сообщения.
    // г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    // д) ***Создать метод, который производит частотный анализ текста. 
    // В качестве параметра в него передается массив слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
    // Здесь требуется использовать класс Dictionary.
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите предложение");
            string str = Console.ReadLine();
            Console.WriteLine("Введите количество букв");
            WordMethod.MoreNLetter(str, int.Parse(Console.ReadLine()));
            Console.WriteLine("Введите символ на который оканивается не угодное слово");
            WordMethod.DeleteWord(str,char.Parse(Console.ReadLine()));
            Console.WriteLine($"самое длинное слово {WordMethod.FindLongWord(str)}");
            WordMethod.LongWords(str);
            WordMethod.FreqMass(str, WordMethod.FillMassivWord());
        }
    }
}