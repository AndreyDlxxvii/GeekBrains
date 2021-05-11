using System;

namespace Task3_2
{
    class Program
    {
        //Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
        //Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой)
        //Выполнить задание, оформив вычисления расстояния между точками в виде метода;
        //Худоерко Андрей
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты x первой точки");
            double X1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите координаты y первой точки");
            double Y1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите координаты x второй точки");
            double X2 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите координаты y второй точки");
            double Y2 = double.Parse(Console.ReadLine());
            
            NewMethod(X2, X1, Y2, Y1);
            
            Console.ReadLine();
        }

        private static void NewMethod(double X2, double X1, double Y2, double Y1)
        {
            var sum = (Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2)));
            Console.WriteLine($"Растояние между двумя точками равно: {sum:f2}");
        }
    }
}