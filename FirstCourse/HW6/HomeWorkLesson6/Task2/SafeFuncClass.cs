using System;
using System.Collections.Generic;
using System.IO;

namespace Task2
{
    class SafeFuncClass
    {
        public static void SaveFunc(Ex2.Del del, string fileName, double a,double b,double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x<=b)
            {
                bw.Write((double) del?.Invoke(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static List<double> Load(string fileName)
        {
            List<double> listOfMin = new List<double>();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for(int i=0;i<fs.Length/sizeof(double);i++)
            {
                d = bw.ReadDouble();
                listOfMin.Add(d);
                if (d < min)
                {
                    min = d;
                }
            }
            bw.Close();
            fs.Close();
            return listOfMin; // Возврат списка считанных значений
        }

        public static void PrintMin(List<double> listOfMin, out double min) // Возвращение минимального значения по параметру out
        {
            listOfMin.Sort();
            min = listOfMin[0];
        }

        public static Ex2.Del GetFuncOfNumber(int num) // Список делегатов вызываемое по нажатой пользователем цифре
        {
            switch (num)
            {
                case 1:
                    return x => 2*x;
                case 2:
                    return x => x*10+10;
                case 3:
                    return x => x*10-10;
                case 4:
                    return x => x * x-50*x+10;
                default: throw new Exception("Нет такой функции");
            }
        }
    }
}