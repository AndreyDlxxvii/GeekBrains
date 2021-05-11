using System;

namespace Task1
{
    class TableClass
    {
        public delegate double Fun (double x, double y);
        public static double MyFunc(double x, double y) => x * x * x;

        public static double MyFunSin(double a, double x) => a * Math.Sin(x);

        public static double MyFunSquare(double x, double a) => a * Math.Pow(x, 2);
        public static void Table(Fun Funfun, double x, double y, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, Funfun(x, y));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
    }
}