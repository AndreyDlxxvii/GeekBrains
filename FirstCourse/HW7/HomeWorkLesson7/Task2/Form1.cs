using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Logical = new Logical(this);
        }

        private Logical Logical { get; }

        private void button1_Click(object sender, EventArgs e)//Нажатие на кнопку проверки числа
        {
            string i;
            if (textBox1.Text != String.Empty)
            {
                i = textBox1.Text;
                label2.Text = i;
            }
            else i = label2.Text;
            Logical.CheckNumber(i);
            textBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }//Рестарт приложения
        
        private void button3_Click(object sender, EventArgs e)//Открытие ввода через окно
        {
            Form2 newForm = new Form2 {txt = label2};
            newForm.Show();
        }
    }
}