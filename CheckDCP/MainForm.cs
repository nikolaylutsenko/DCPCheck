using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckDCP
{
    public partial class MainForm : Form
    {
        // Инициализация базового класса для работы программы
        Worker worker = new Worker();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание диалогового окна для выбора папки
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // Внесение адреса выбранной папки в поле на форке 
                    labelPath.Text = worker.SetFolderName(fbd.SelectedPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Запуск проверки суммы
            worker.StartCheck();

            // Получение списка PKL-файлов
            richTextBoxHashCheckResult.Lines = worker.ShowAllFileWithPKL();

            // Получение итоговой информации о проверке (временное)
            richTextBox2.Lines = worker.GetInfoAboutCheck();
        }
    }
}
