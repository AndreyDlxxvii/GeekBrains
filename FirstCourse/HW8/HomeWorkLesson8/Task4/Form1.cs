using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class Form1 : Form
    {
        // Используя полученные знания и класс TrueFalse в качестве шаблона, 
        // разработать собственную утилиту хранения данных
        // (Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).
        // Худоерко Андрей

        EnglishRusDict _dictionary;
        public Form1()
        {
            InitializeComponent();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                _dictionary = new EnglishRusDict(sfd.FileName);
                _dictionary.Add(textBoxEng.Text, textBoxRus.Text);
                _dictionary.Save();

            };
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                _dictionary = new EnglishRusDict(ofd.FileName);
                try
                {
                    _dictionary.Load();
                }
                catch 
                {
                    MessageBox.Show($"Ошибка открытия файла");
                }
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dictionary == null)
            {
                MessageBox.Show("Сохранять нечего, создайте что-то.");
                return;
            }
            if (_dictionary.Count == 0)
                return;
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath, 
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (!sfd.FileName.EndsWith(".xml"))
                    sfd.FileName += ".xml";
                try
                {
                    _dictionary.FileName = sfd.FileName;
                    _dictionary.Save();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Ошибка сохранения в файл.\n{exception.Message}");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dictionary!= null) _dictionary.Save(); 
            else MessageBox.Show("База данных не создана");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_dictionary==null)
            {
                MessageBox.Show("Создайте новую базу данных","Сообщение");
                return;
            }
            _dictionary.Add(textBoxEng.Text, textBoxRus.Text);
            textBox1.Text = $"Колчиество слов {_dictionary.Count}";
        }

      

        private void delButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dictionary==null)
                {
                    MessageBox.Show("Создайте новую базу данных","Сообщение");
                    return;
                }
                textBoxEng.Text = _dictionary[_dictionary.Count - 1].EngWord;
                textBoxRus.Text = _dictionary[_dictionary.Count - 1].RusWord;
                _dictionary.Remove(_dictionary.Count-1);
                textBox1.Text = $"Колчиество слов {_dictionary.Count+1}";

            }
            catch
            {
                MessageBox.Show("Нечего удалять");
            }
            
        }
    }
}