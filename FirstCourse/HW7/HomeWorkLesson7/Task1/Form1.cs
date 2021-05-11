using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        private int countPush = 0;
        private int number = 0;
        private int endGame = 0;
        private Stack<int> numbers = new Stack<int>();
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            endGame = r.Next(1, 500);
            label3.Text = $"Необходимо получить число {endGame} за минимальное количество ходов";
            lblCounter.Text = "Количество нажатий";
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            label5.Text = endGame.ToString();
            this.Text = "Удвоитель";
            LogicalWin();
        }

        

        private void btnCommand1_Click(object sender, EventArgs e)//Увеличение числа на 1
        {
            
            number +=1;
            numbers.Push(number);
            lblNumber.Text = (number.ToString());
            Counter();
            LogicalWin();
        }

        private void btnCommand2_Click(object sender, EventArgs e)//Умножение числа на 2
        {
            
            number *=2;
            numbers.Push(number);
            lblNumber.Text = number.ToString();
            Counter();
            LogicalWin();
        }

       private void btnReset_Click(object sender, EventArgs e)//Сброс числа
        {
        
            lblNumber.Text = "0";
            number = 0;
            Counter();
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)//Инициализация интерфейса
        {
            lblCounter.Enabled = true;
            btnCommand1.Enabled = true;
            btnCommand2.Enabled = true;
            btnReset.Enabled = true;
            lblNumber.Enabled = true;
            lblCounter.Enabled = true;
            button4.Enabled = true;
            label5.Enabled = true;
            label3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)//Отмена предыдущего действия
        {
            if (numbers.Count!=0)
            {
                number = numbers.Pop();
                lblNumber.Text = number.ToString();
                Counter();
                LogicalWin();
            }
            else
            {
                lblNumber.Text = "Дальше нет чисел";
            }

        }
        private void LogicalWin() // Проверка победы и вывод поздравления
        {
            if (number==endGame)
            {
                label3.Show();
                label3.Text = $"Поздравляю вы победили за {countPush} ходов";
                lblCounter.Hide();
                btnCommand1.Hide();
                btnCommand2.Hide();
                btnReset.Hide();
                lblNumber.Hide();
                lblCounter.Hide();
                button4.Hide();
                label5.Hide();

            }
        }
        private void Counter()//Счетчик нажатий клавиш в программе
        {
            countPush++;
            lblCounter.Text = $"Количество нажатий {countPush.ToString()}";
        }


    }
}