using System;
using System.Collections.Generic;
using System.Linq;

namespace MyArryLib
{
        public class MyArray
    {
        int[] a;

        public Dictionary<int, int> InitDictionary(int sizeDict, int rndMin, int rndMax)//инициализация словаря заданного размера с рандомными числами и печать количества входов числа
        {
            Dictionary<int, int> dic = new Dictionary<int,int>();
            Random rnd = new Random();
            int count = 0;
            
            for (int j = 0; j < sizeDict; j++)
            {
                dic.Add(j,rnd.Next(rndMin, rndMax));
            }

            for (int i = rndMin; i <= rndMax; i++)
            {
                for (int j = 0; j < sizeDict; j++)
                {
                    if (i==dic[j])
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Колличество входов числа в словаре {i} - {count} раз");
                count = 0;
            }

                //Console.WriteLine($"Колличество вхождений значения {value} - {count} раз");
            
            
            return dic;
        }
        public MyArray(int sizeArray,int elementArray)
        {
            a = new int[sizeArray];
            for (int i = 0; i < sizeArray; i++)
                a[i] = elementArray;
        }

        public MyArray(int sizeArray, int startValue, int step)//Конструктор создающий массив с заданным размером, стартовым значением и шагом
        {
            a = new int [sizeArray];
            a[0] = startValue;
            for (int i = 1; i < sizeArray; i++)
            {
                a[i] = a[i-1] + step;
            }
        }

        public int Sum()//Метод возвращающий сумму всех элементов массива
        {
            int sumAllElMass = 0;
            var count = a.Length;

            for (int i = 0; i < count; i++)
            {
                sumAllElMass += a[i];
            }
            return sumAllElMass;
        }

        public int [] Inverse()//Инвертирование массива
        {
            var count = a.Length;
            int [] r = new int[count];
            for (int i = 0; i < count; i++)
            {
                r[i] = -a[i];
                Console.Write($" {r[i]}");
            }

            Console.WriteLine();

            return r;
        }

        public void Multi(int value)//Умножение каждого элемента массива на value
        {
            int count = a.Length;
            for (int i = 0; i < count; i++)
            {
                a[i] *= value;
            }
        }

        public int MaxCount //Возвращает количество максимальных чисел массива
        {
            get
            {
                int maxCount = 0;
                var count = a.Length;
                var temp = a.Max();
                for (int i = 0; i < count; i++)
                {
                    if (a[i]==temp)
                    {
                        maxCount++;
                    }
                }


                return maxCount;
            }
        }
        
        public int Max
        {
            get 
            { 
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        
        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s=s+v+" ";
            return s;
        }

    }
}