using System;

namespace Task3
{
    // Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
    // Написать программу, демонстрирующую все разработанные элементы класса.
    // * Добавить свойства типа int для доступа к числителю и знаменателю;
    // * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    // ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    // *** Добавить упрощение дробей.
    // Андрей Худоерко

    class Program
    {
        class Fraction
        {
            int _numerator;
            int _denominator;

            public Fraction()
            {
                _numerator = 1;
                _denominator = 1;
            }

            public Fraction(int numerator , int denominator)
            {
                _numerator = numerator;
                if (denominator != 0)
                {
                    _denominator = denominator;
                }
                else throw new ArgumentException("Знаменатель не может быть равен 0");
            }

            public double SetGetNumerator//доступ на чтение запись - числитель
            {
                get { return _numerator; }
                set
                {
                    if (value > 0)
                    {
                        _numerator = (int) value;
                    }
                    else _numerator = (int) -value;

                }
            }
            
            public double SetGetDenominator//доступ на чтение запись - знаменатель
            {
                get { return _denominator; }
                set
                {
                    if (value > 0)
                    {
                        _denominator = (int) value;
                    }
                    else if (value < 0)
                    {
                        _denominator = (int) -value;
                    }
                    else throw new ArgumentException("Знаменатель не может быть равен 0");

                }
            }

            public double GetDecimal//представление в виде десятичной дроби
            {

                get
                {
                    double temp = (double)_numerator / (double)_denominator;
                    return Math.Round(temp,3);
                }
            }

            public string PrintFraction()
            {
                if (_numerator > 0 && _denominator > 0)
                {
                    return _numerator + "/" + _denominator;
                }
                else if (_numerator < 0)
                {
                    return "-" + _numerator*-1 + "/" + _denominator;
                }
                else if (_denominator < 0)
                {
                    return "-" + _numerator+ "/" + _denominator*-1;
                }
                else
                {
                    return "-" + _numerator*-1 + "/" + _denominator*-1;
                }
            }

            public Fraction Plus(Fraction fraction)//сложение
            {
                Fraction result = new Fraction();
                //result._numerator = _numerator + fraction._numerator;
                if (_denominator!=fraction._denominator)
                {
                    result._numerator = _numerator*fraction._denominator + fraction._numerator*_denominator;
                    result._denominator = _denominator * fraction._denominator;
                }
                else
                {
                    result._numerator = _numerator + fraction._numerator;
                    result._denominator = _denominator;
                }
                return result;
            }

            public Fraction Subtract(Fraction fraction)//вычитание
            {
                Fraction result = new Fraction();
                if (_denominator!=fraction._denominator)
                {
                    result._numerator = _numerator*fraction._denominator - fraction._numerator*_denominator;
                    result._denominator = _denominator * fraction._denominator;
                }
                else
                {
                    result._numerator = _numerator - fraction._numerator;
                    result._denominator = _denominator;
                }
                return result;
            }
            
            public Fraction Multi(Fraction fraction)//умножение
            {
                Fraction result = new Fraction();
                result._numerator = _numerator * fraction._numerator;
                result._denominator = _denominator * fraction._denominator;
                return result;
            }
                
            public Fraction Division(Fraction fraction)//деление
            {
                Fraction result = new Fraction();
                result._numerator = _numerator * fraction._denominator;
                result._denominator = _denominator * fraction._numerator;
                return result;
            }

            public Fraction Simplification()//упрощение дробей
            {
                Fraction result = new Fraction();
                var temp = Math.Min(_numerator, _denominator);
                for (; temp > 0; temp--)
                {
                    if (_numerator % temp == 0 && _denominator % temp == 0)
                    {
                        result._numerator = _numerator / temp;
                        result._denominator = _denominator / temp;
                        break;
                    }
                }
                return result;
            }
        }
        
                                    
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(3,21);
            Fraction fraction2 = new Fraction(7, 5);
            Console.WriteLine($"Дробь 1: {fraction1.PrintFraction()}  Дробь 2: {fraction2.PrintFraction()}");
            Console.WriteLine($"Сумма дробей {fraction1.Plus(fraction2).PrintFraction()}");
            Console.WriteLine($"Разность дробей {fraction1.Subtract(fraction2).PrintFraction()}");
            Console.WriteLine($"Произведение дробей {fraction1.Multi(fraction2).PrintFraction()}");
            Console.WriteLine($"Деление дробей {fraction1.Division(fraction2).PrintFraction()}");
            Console.WriteLine($"Упрощение дроби {fraction1.Simplification().PrintFraction()}");
            Console.WriteLine($"Представление дроби в виде десятчиной части {fraction1.Simplification()}");
            fraction1.SetGetNumerator = 5; //присвоение первой дроби числителя 5
            fraction2.SetGetDenominator = fraction1.SetGetNumerator; // присвоение второй дроби знаменателя равного числителю первой броби
            // Console.WriteLine($"Вызов исключения при присвоении знаменателю 0");
            // fraction1.SetGetDenominator = 0;
            
           
            Console.ReadLine();
        }
    }
}