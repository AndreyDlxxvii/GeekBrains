using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public List<Student> std = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            int j = 0;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                std = Transformer.ReadFromCsv(ofd.FileName);
                for (int k = 0; k < std.Count; k++)
                {
                    textBox1.AppendText(std[k].ToString() + Environment.NewLine);
                }
            }

        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                InitialDirectory = Application.StartupPath, 
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                Transformer.WriteToXml(std,dialog.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка записи в файл:\n" + exception.Message);
            }
        }
    }
}