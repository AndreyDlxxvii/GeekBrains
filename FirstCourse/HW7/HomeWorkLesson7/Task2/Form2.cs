using System;
using System.Windows.Forms;

namespace Task2
{
    
    public partial class Form2 : Form
    {
        public Label txt;

        public Form2()
        {
            InitializeComponent();
        }
  
        private void button1_Click(object sender, EventArgs e)//Подтверждение ввода во внешнем окне
        {
            txt.Text = textBox1.Text;
            Hide();
        }
    }
}