using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
         // База данных с вопросами
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }
        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("Введите вопрос", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database==null)
            {
                MessageBox.Show("Создайте новую базу данных","Сообщение");
                return;
            }
            database.Add((database.Count+1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database==null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value>1) nudNumber.Value = nudNumber.Value;
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
           if (database!= null) database.Save(); 
             else MessageBox.Show("База данных не создана");
        } 
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                try
                {
                    database.Load();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                }
                catch 
                {
                    MessageBox.Show($"Ошибка открытия файла");
                }
            }
        }
        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value-1].Text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Прежде чем сохранять, создайте или откройте базу");
            }

        }
        // Обработчик сохранить как
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Сохранять нечего, создайте что-то.");
                return;
            }
            if (database.Count == 0)
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
                    database.FileName = sfd.FileName;
                    database.Save();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Ошибка сохранения в файл.\n{exception.Message}");
                }
            }

        }
        
        //О программе
        private void abouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formAbout = new FormAbout();
            formAbout.Show();
        }
    }
}
