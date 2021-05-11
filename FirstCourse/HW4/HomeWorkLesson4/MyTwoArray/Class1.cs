using System;
using System.IO;
using System.Text;

namespace MyTwoArray
{
    public class MyArray
    {

        private int[,] _array;
        private int _minValue;
        private int _maxValue;

        
        public MyArray(int sizeFirst, int sizeSecond, int rndMin, int rndMax)//Конструктор инициализирующий двумерный массив с проивзольными числами
        {
            _array = new int[sizeFirst,sizeSecond];
            Random rnd = new Random();
            for (int i = 0; i < sizeFirst; i++)
            {
                for (int j = 0; j < sizeSecond; j++)
                {
                    _array[i, j] = rnd.Next(rndMin, rndMax);
                }
            }
        }

        public MyArray(string path) //Конструктор создающий двумерный массив из файла
        {
            int x = 0;
            int y = 0;

            try
            {
                StreamReader sr = new StreamReader(path);
                if (File.ReadAllLines(path).Length % 2 == 0)
                {
                    x = 2;
                    y = File.ReadAllLines(path).Length/2;
                }
                else
                {
                    x = 1;
                    y = File.ReadAllLines(path).Length;
                }

                _array = new int[x, y];
                try
                {
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            _array[i, j] = int.Parse(sr.ReadLine());
                        } 
                    }
                }
                catch 
                {
                    Console.WriteLine("Не верный формат данных в файле");
                }
            }
            catch 
            {
                Console.WriteLine("Не верный адрес файла");
            }
        }
        
        public int Sum() //Метод возвращающий сумму всех элементов массива
        {
            int sumAllEllement = 0;
            foreach (var ellement in _array)
            {
                sumAllEllement += ellement;
            }
            return sumAllEllement;
        }
        
        public int SumMoreThan(int maxEllement) //Метод возвращающий сумму всех элементов массива после заданного номера массива
        {
            int sumAllEllement = 0;
            int i = 0;
            foreach (var ellement in _array)
            {
                i++;
                if (i>maxEllement)
                {
                    sumAllEllement += ellement;
                }
            }
            return sumAllEllement;
        }

        public int MinValue //Свойство возвращает минимальный элемент массива
        {
            get
            {
                _minValue = _array[0, 0];
                foreach (var ellement in _array)
                {
                    if (ellement<_minValue)
                    {
                        _minValue = ellement;
                    }
                }
                return _minValue;
            }
        }
        
        public int MaxValue //Свойство возвращает максимальный элемент массива
        {
            get
            {
                _maxValue = _array[0, 0];
                foreach (var ellement in _array)
                {
                    if (ellement>_maxValue)
                    {
                        _maxValue = ellement;
                    }
                }
                return _maxValue;
            }
        }

        public void NumMaxEllement(ref int t, out int x, out int y)//Метод возвращающий номер элемента максимального значения
        {
            int tempX=0;
            int tempY=0;
            for (int i = 0; i < _array.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _array.GetUpperBound(1); j++)
                {
                    if (_array[i, j] == t)
                    {
                        tempX = i;
                        tempY = j;
                        i = _array.GetUpperBound(0);
                        j = _array.GetUpperBound(1);
                    }
                }
            }

            x = tempX;
            y = tempY;
        }

        public string ToStringArr()//Запись массива в строку
        {
            string res = null;
            for (int i = 0; i <= _array.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= _array.GetUpperBound(1); j++)
                {
                    res += $"Элемент [{i}, {j}] - {_array[i, j]} ";
                }
            }

            return res;
        }

        public async void WriteToFile(string path , string res) //Вывод массива в файл
        {
            var q = res;
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default ))
                {
                    await sw.WriteLineAsync(res);
                }
                
                Console.WriteLine("Информация записана в файл");
                
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
        }
        
        
    }
}

