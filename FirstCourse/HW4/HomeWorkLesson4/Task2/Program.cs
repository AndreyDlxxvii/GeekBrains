using System;
using System.Collections.Concurrent;
using System.IO;

namespace Task2
{
    // Реализуйте задачу 1 в виде статического класса StaticClass;
    // а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    // б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
    // в)**Добавьте обработку ситуации отсутствия файла на диске.
    // Худоерко Андрей

    static class MyArray
    {
        public static int CountAllDoudleNum(int[] array) //решение 1 задачи с поиском пары чисел одно из которых делится на 3
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % 3 == 0 && array[i + 1] % 3 != 0 || array[i] % 3 != 0 && array[i + 1] % 3 == 0)
                {
                    count++;
                    //Console.WriteLine($"Пара чисел {array[i]} {array[i+1]}");
                }
            }

            return count;
        }

        public static int[] ReadFromFile(string path) //Считывание данных с файла с проверкой на отсутствие файла и неверных данных в файле
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                int[] array = new int [File.ReadAllLines(path).Length];
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    try
                    {
                        array[i] = int.Parse(temp);
                        i++;
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка считывания данных в файле");
                    }
                }

                return array;
            }
            catch 
            {
                Console.WriteLine("Ошибка, отсутствует файл");
            }

            return null;
        }

        static int[] Mass()//заполнение массива рандомными числами от -10000 до 10000
        {
            Random rnd = new Random();
            int[] mass = new int [20];

            for (int i = 0; i < mass.Length; i++)  
            {
                mass[i] = rnd.Next(-10000, 10000);
            }

            return mass;
        }


        class Program
        {
            static void Main(string[] args)
            {
                string path = @"..\..\data.txt";
                
                Console.WriteLine($"Количество подходящих пар чисел в массиве рандомных чисел {MyArray.CountAllDoudleNum(Mass())}");
                if (ReadFromFile(path) != null)
                {
                    Console.WriteLine($"Количество подходящих пар чисел в файле {MyArray.CountAllDoudleNum(ReadFromFile(path))}");
                }
            }
        }
    }
}