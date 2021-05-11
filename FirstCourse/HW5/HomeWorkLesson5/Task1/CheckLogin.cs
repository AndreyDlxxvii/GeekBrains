using System;
using System.Text.RegularExpressions;

namespace HomeWorkLesson5
{
    static class CheckLogin
    {
        public static void CheckRegular (string str) //Метод с использованием регулярных выражений
        {
            Regex reg = new Regex(@"^[A-z][A-z\d]{1,9}$");
            if (reg.IsMatch(str))
            {
                Console.WriteLine("Логин подходит");
            }
            else Console.WriteLine("Не подходит");
        }
        
        public static void Check(string str)//метод проверки без использования регулярных выражений
        {
            bool flag = false;
            if (str.Length >= 2 && str.Length <= 10 && !Char.IsDigit(str[0]))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    
                    if (str[i]>='a' && str[i]<='z' || Char.IsDigit(str[i]))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    
                }
            }

            switch (flag)
            {
                case true:
                    Console.WriteLine("Логин подходит");
                    break;
                case false:
                    Console.WriteLine("Логин не подходит");
                    break;
            }
        }
        
    }
}