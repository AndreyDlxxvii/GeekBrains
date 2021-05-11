using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Channels;

namespace HomeWorkLesson5
{
    // Создать программу, которая будет проверять корректность ввода логина. 
    // Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита 
    // или цифры, при этом цифра не может быть первой:
    // а) без использования регулярных выражений;
    // б) **с использованием регулярных выражений.
    // Худоерко Андрей
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Введите логин от 2 до 10 символа, содержащий только буквы латинского 
                                алфавита или цифры, при этом цифра не может быть первой");
            string str = Console.ReadLine();

            CheckLogin.Check(str);
            CheckLogin.CheckRegular(str);

        }
    }
}