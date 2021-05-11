using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    static class WordMethod
    {
        public static string[] FillMassivWord()//инициализация массива слов 
        {
            Console.WriteLine("Введите размер предполагаемого массива");
            string[] word = new string [int.Parse(Console.ReadLine())];
            Console.WriteLine("Вводите слова");
            for (int i = 0; i < word.Length; i++)
            {
                word[i] = Console.ReadLine();
            }

            return word;
        }
        public static void MoreNLetter(string str, int wordLength) //Вывод слов сообщения меньше n букв
        {
            char [] separator = new char[] {' ', ','};
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Слова меньше {wordLength} букв");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length<wordLength)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }

        public static void DeleteWord(string str, char ch) //Удаление из предложения слова заканчивающееся на определенный символ
        {
            char [] separator = new char[] {' ', ','};
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Результат");
            for (int i = 0; i < words.Length; i++)
            {
                if (!words[i].EndsWith(ch))
                {
                    Console.Write(words[i] + " ");
                }
            }
        }

        public static string FindLongWord(string str)//Вывод самого длинног слова
        {
            char [] separator = new char[] {' ', ','};
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            var result = words[0];
            
            foreach (var word in words)
            {
                if (result.Length<word.Length)
                {
                    result = word;
                }
            }

            //Console.WriteLine($"Cамое длинное слово: {result}");
            return result;
        }

        public static void LongWords(string str)//Формовка строки из самых длинных слов
        {
            StringBuilder stringBuilder = new StringBuilder();
            int maxLength = FindLongWord(str).Length;
            Regex reg = new Regex("\\w{" + maxLength + "}\\b");
            var t = reg.Matches(str);
            foreach (var ell in t)
            {
                if (ell.ToString().Length == maxLength)
                {
                    stringBuilder.Append(ell);
                    stringBuilder.Append(' ');
                }
            }

            Console.WriteLine(stringBuilder);
        }

        public static void FreqMass(string str, string [] word)
        {
            int t = 0;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            char[] separ = {' ', ','};
            var temp = str.Split(separ, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < temp.Length; j++)//Инициализация словаря со словами
            {
                dictionary.Add(j,temp[j]);
            }

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    if (dictionary[j]==word[i])
                    {
                        t++;
                    }
                }

                Console.WriteLine($"Слово {word[i]} встретилось {t} раз");
                t = 0;
            }

            

            Console.WriteLine();
        }
    }
}