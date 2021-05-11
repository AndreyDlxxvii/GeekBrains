using System;
using System.Collections.Generic;

namespace Task2
{
    public class Logical
    {

        private Form1 _form1;
       
        static Random rnd = new Random();
        int finalNum = rnd.Next(1, 100);
        
        public Logical(Form1 form1)
        {
            _form1 = form1;
        }

        public void CheckNumber(string number)//Проверка введенного числа
        {
            
            if (int.TryParse(number, out var num))
            {
                if (num < finalNum)
                {
                    _form1.label1.Text = InitStringList(false);
                }
                else if (num > finalNum)
                {
                    _form1.label1.Text = InitStringList(true);
                }
                else
                {
                    _form1.label1.Text = "Поздравляю, Вы угадали загаданое число!";
                    _form1.button1.Hide();
                    _form1.textBox1.Hide();
                }
            }
            else
            {
                _form1.label1.Text = "Введено не число";
            }
        }

        private string InitStringList(bool i)//Вывод сообщения в зависимости от того больше число или меньше
        {
            List<string> variant = new List<string>
            {
                "Ваше число больше загаданного",
                "Явно больше того что загадано",
                "Попробуй маленько меньшее числовое значение",
                "Число больше",
                "Ваше число меньше загаданного",
                "Явно меньше того что загадано",
                "Попробуй маленько большее числовое значение",
                "Число меньшее",
            };

            if (i)
            {
                return variant[rnd.Next(0,3)];
            }

            return variant[rnd.Next(4,7)];
        }
    }
}