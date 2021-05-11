using System;

namespace Task2
{
    internal class Ex2
    {
        public delegate double Del(double x);
        public static double F(double x) => x * x-50*x+10;
        public static void Start()
        {
            double min;
            Console.WriteLine("Введите номер функции 1-4");
            int num = int.Parse(Console.ReadLine());
            SafeFuncClass.SaveFunc(SafeFuncClass.GetFuncOfNumber(num), "data.bin", -100, 100, 0.5);
            SafeFuncClass.PrintMin(SafeFuncClass.Load("data.bin"),out min);
            Console.WriteLine($"Минимальное число {min}");
            Console.ReadKey();
        }
    }
}