using System;
using System.ComponentModel.Design;

namespace Task4
{
    class Program
    {
        static int i = 0;
        // Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
        // На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
        // Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
        // С помощью цикла do while ограничить ввод пароля тремя попытками
        
        // Худоерко Андрей
        static void Main(string[] args)
        {
            int i = 0;
            
            CheckLoginPass();
        }

        private static void CheckLoginPass()
        {
            i++;
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string pass = Console.ReadLine();
            
            if (login == "root" && pass == "GeekBrains")
            {
                Console.WriteLine("Верный пароль логин");
                SomeMethod();
                return;
            }
            else if (i==3)
            {
                Console.WriteLine("Превышено число попыток");
                return;
            }
            else CheckLoginPass();

        }

        private static void SomeMethod()
        {
            Console.WriteLine("Добро пожаловать");
        }
    }
}