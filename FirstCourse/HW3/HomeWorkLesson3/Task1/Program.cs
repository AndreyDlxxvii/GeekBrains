using System;

namespace HomeWorkLesson3
{
    // Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
    // Худоерко Андрей
    struct Complex
    {
        public double im;
        public double re;
        
        public Complex Plus(Complex x) //сложение
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Multi(Complex x) //умножение
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public Complex Subtract(Complex x) //вычитания
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public string ToString() 
        {
            return re + "+" + im + "i";
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            Complex complex1;
            complex1.re = 1;
            complex1.im = 1;

            Complex complex2;
            complex2.re = 2;
            complex2.im = 2;

            Complex result = complex1.Plus(complex2);
            Console.WriteLine(result.ToString());
            result = complex1.Multi(complex2);
            Console.WriteLine(result.ToString());
            result = complex2.Subtract(complex1);
            Console.WriteLine(result.ToString());

        }
    }
}