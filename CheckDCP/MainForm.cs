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
        string adrs = "";
        // Инициализация базового класса для работы программы
        Worker worker = new Worker();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen(object sender, EventArgs e)
        {
            // Создание диалогового окна для выбора папки
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // Внесение адреса выбранной папки в поле на форке 
                    labelPath.Text = worker.SetFolderName(fbd.SelectedPath);
                    adrs = fbd.SelectedPath;
                }
            }
        }

        private void btnCheck(object sender, EventArgs e)
        {
            #region Старый код
            //// Запуск проверки суммы
            //worker.StartCheck();

            //// Получение списка PKL-файлов
            //richTextBoxHashPklCheckResult.Lines = worker.ShowAllFileWithPKL();

            //// Получение итоговой информации о проверке (временное)
            //richTextBox2.Lines = worker.GetInfoAboutCheck();
            #endregion

            worker.ReadListAssetmap();
            //находим Ассетмап
            richTextBoxHashPklCheckResult.Lines = worker.FindList(adrs,true).ToArray();
            //парсим его
            worker.ReadListAssetmap();
            richTextBoxHashPklCheckResult.Lines = worker.GetInfoFromAssetmap();
            //дополняем инфу о ассетах из пкл файла
            worker.ReadPkl();
            worker.CalcHash();
            richTextBoxHashPklCheckResult.Lines = worker.GetInfoFromPkl();




        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBoxHashPklCheckResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
