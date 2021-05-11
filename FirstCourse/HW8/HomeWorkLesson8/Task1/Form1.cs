using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyStructInfo();
        }

        private void MyStructInfo()
        {
            richTextBox1.AppendText("\n Свойства структуры");
            foreach (var ell in typeof(DateTime).GetProperties())
            {
                richTextBox1.AppendText("\n" + ell);
            }
        }
    }
    
}
