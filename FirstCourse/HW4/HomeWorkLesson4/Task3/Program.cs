using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using MyArryLib;

namespace Task3
{
    // а) Дописать класс для работы с одномерным массивом. Реализовать конструктор,
    // создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом.
    // Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse,
    // возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),
    // метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
    // б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
    // в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
    // Худоерко Андрей
    

    class Program
    {
        static void Main(string[] args)
        {
            
            MyArray array = new MyArray(10, 0,1); // конструктор массива заполняющий его с шагом от начального значения
            var q = array.InitDictionary(50,0,10); // создание массива через словарь и печать количества входов
            Console.WriteLine(array.ToString()); //печать массива
            Console.WriteLine(array.Sum()); // сумма всех элементов массива
            var i = array.Inverse(); //инверсия массива
            array.Multi(2); //умножение каждого элемента массива
            Console.WriteLine(array.ToString());
            Console.WriteLine(array.MaxCount); //возврат количества максимальных значений
            Console.ReadLine();
        }
    }
}