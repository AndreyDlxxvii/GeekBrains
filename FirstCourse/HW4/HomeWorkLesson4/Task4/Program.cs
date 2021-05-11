using System;
using System.IO;

namespace Task4
{
    //Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
    //Создайте структуру Account, содержащую Login и Password

    // Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
    // На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
    // Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
    // С помощью цикла do while ограничить ввод пароля тремя попытками

    // Худоерко Андрей
    struct Account
    {
        private static string _login;
        private static string _password;
        private static int i = 0;


        public Account(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public string[] ReadFromFile(string path) //Считывание данных с файла с проверкой на отсутствие файла и неверных данных в файле
        {
            try
            {
                StreamReader sr = new StreamReader(path);
                string[] array = new string [File.ReadAllLines(path).Length];
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();

                    array[i] = temp;
                    i++;
                }

                return array;
            }
            catch
            {
                Console.WriteLine("Ошибка, отсутствует файл");
            }

            return null;
        }

        public void CheckLoginPass()
        {

            i++;

            if (_login == "root" && _password == "GeekBrains")
            {
                Console.WriteLine("Верный пароль логин");
                SomeMethod();
                return;
            }
            else 
            {
                Console.WriteLine("Не верная пара логин/пароль");
                return;
            }
        }

        private static void SomeMethod()
        {
            Console.WriteLine("Добро пожаловать");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\Account.txt";
            Account a = new Account(a.ReadFromFile(path)[0],a.ReadFromFile(path)[1]);
            a.CheckLoginPass();
        }
    }
}
