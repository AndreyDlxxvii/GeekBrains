using System;

namespace Task1
{
    internal class Ex1
    { 
        public static void Start()
        {
            Console.WriteLine("Вычисление куба числа х");
            TableClass.Table(TableClass.MyFunc,2,4,7);

            Console.WriteLine("Вычисление произведение синуса");
            TableClass.Table(TableClass.MyFunSin, 5,6,10);
            
            Console.WriteLine("Вычисление квадрата");
            TableClass.Table(TableClass.MyFunSquare,1,2,4);
        }
    }
}