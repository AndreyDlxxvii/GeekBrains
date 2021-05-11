using System;

namespace HomeWorkLesson3
{
    // Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
    // Добавить диалог с использованием switch демонстрирующий работу класса
    // Худоерко Андрей
    class Complex
    {
        
        double _im, _re;

        public Complex()
        {
            _im = 0;
            _re = 0;
        }

        public Complex(double im, double re)
        {
            _im = im;
            _re = re;
        }
        public Complex Plus(Complex x2) //сложение
        {
            Complex x3 = new Complex();
            x3._im = x2._im + _im;
            x3._re = x2._re + _re;
            return x3;
        }
        public Complex Subtract(Complex x2) //вычитание
        {
            Complex x3 = new Complex();
            x3._im = _im - x2._im;
            x3._re = _re - x2._re;
            return x3;
        }
        public Complex Multi(Complex x2) //умножение
        {
            Complex x3 = new Complex();
            x3._im = _re * x2._im + _im * x2._re;
            x3._re = _re * x2._re - _im * x2._im;
            return x3;
        }
       public double Im
        {
            get { return _im; }
            set
            {
                if (value >= 0) _im = value;
            }
        }
        public string ToString()
        {
            return _re + "+" + _im + "i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex complex1 = new Complex(1, 1);
            Complex complex2 = new Complex(2, 2);
            Console.WriteLine("Нажмите цифру соответствующую необходимым действиям над числами.");
            Console.WriteLine("1: Сложить комплексное число 1 и комплексное число 2");
            Console.WriteLine("2: Вычесть комплексное число 1 из комплексного числа 2");
            Console.WriteLine("3: Перемножить комплексное число 1 на комплексное число 2");
            
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Complex result = complex1.Plus(complex2);
                    Console.WriteLine($"Результат сложнеия числе {result.ToString()}");
                    break;
                case 2:
                    Complex result2 = complex2.Subtract(complex1);
                    Console.WriteLine($"Разность второго и первого числа {result2.ToString()}");
                    break;
                case 3:
                    Complex result3 = complex1.Multi(complex2);
                    Console.WriteLine($"Произведение двух комплексных чисел {result3.ToString()}");
                    break;
            }
        }
    }
}
