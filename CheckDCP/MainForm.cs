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
using System.Text.RegularExpressions;

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

        /// <summary>
        /// Обработка выбора папки
        /// </summary>
        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            // Создание диалогового окна для выбора папки
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SetSelectedPath(fbd.SelectedPath);
                }
            }
        }
        
        /// <summary>
        /// Обработка проверки файлов
        /// </summary>
        private void buttonCheckFile_Click(object sender, EventArgs e)
        {
            #region Старый код
            //// Запуск проверки суммы
            //worker.StartCheck();

            //// Получение списка PKL-файлов
            //richTextBoxHashPklCheckResult.Lines = worker.ShowAllFileWithPKL();

            //// Получение итоговой информации о проверке (временное)
            //richTextBox2.Lines = worker.GetInfoAboutCheck();
            //worker.ReadListAssetmap();
            ////находим Ассетмап
            //worker.FindList(adrs).ToArray();
            ////парсим его
            //worker.ReadListAssetmap();
            //richTextBoxHashPklCheckResult.Lines = worker.GetInfoFromAssetmap();
            ////дополняем инфу о ассетах из пкл файла
            //worker.ReadPkl();
            //worker.CalcHash();
            //richTextBoxHashPklCheckResult.Lines = worker.GetInfoFromPkl();
            #endregion
            // Получение списка пакетов выбранных пользователем и передача списка рабочему классу
            if (checkedListBoxAnnotationText.CheckedItems.Count != 0)
            {
                List<string> selectedItems = new List<string>();

                for (int i = 0; i < checkedListBoxAnnotationText.CheckedItems.Count; i++)
                {
                    selectedItems.Add(checkedListBoxAnnotationText.CheckedItems[i].ToString());
                }

                // Передача рабочему классу списка контента, который выбрал пользователь
                worker.SetSelectedItems(selectedItems.ToArray());

                // Запуск фоновой работы
                backgroundWorker.RunWorkerAsync();

                // Активация прогрессбара
                progressBar.Visible = true;

                buttonSelectPath.Enabled = false;
                menuItemManualFolder.Enabled = false;
            }
            else
            {
                MessageBox.Show("Не выбран ни один из DCP-пакетов.\nПожалуйста, отметьте флажками DCP-пакеты, которые необходимо проверить!",
                    "Ошибка проверки DCP-пакетов", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработка функции "Выделить все"
        /// </summary>
        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                for (int i = 0; i < checkedListBoxAnnotationText.Items.Count; i++)
                {
                    checkedListBoxAnnotationText.SetItemChecked(i, true);
                    checkBoxSelectAll.Text = "Снять выделение";
                }
            }
            else
            {
                for (int i = 0; i < checkedListBoxAnnotationText.Items.Count; i++)
                {
                    checkedListBoxAnnotationText.SetItemChecked(i, false);
                    checkBoxSelectAll.Text = "Выделить всё";
                }
            }
        }

        /// <summary>
        /// Обработка копирования результатов в буфер
        /// </summary>
        private void buttonCopyResultInBuffer_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBoxResult.Text);
        }
        
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;

            backgroundWorker.WorkerReportsProgress = true;

            e.Result = worker.CheckFiles(backgroundWorker);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                richTextBoxResult.Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                richTextBoxResult.Text = "Canceled";
            }
            else
            {

                // Вывод результатов в текстовое поле
                richTextBoxResult.Lines = worker.GetCheckResult();

                foreach (string item in richTextBoxResult.Lines)
                {
                    if (Regex.IsMatch(item, @"^ - "))
                    {
                        richTextBoxResult.Find(item);
                        richTextBoxResult.SelectionColor = Color.Red;
                    }
                }

                // Останова прогрессбара
                progressBar.Visible = false;

                buttonSelectPath.Enabled = true;
                menuItemManualFolder.Enabled = true;

                MessageBox.Show("Проверка успешно завершена", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuItemManualFolder_Click(object sender, EventArgs e)
        {
            Form MSP = new ManualSelectPath();
            MSP.ShowDialog();

            if (Options.SelectedPath != null)
            {
                SetSelectedPath(Options.SelectedPath);
                Options.SelectedPath = null;
            }
        }

        void SetSelectedPath(string selectedPath)
        {
            // Внесение адреса выбранной папки в поле на форке 
            labelPath.Text = selectedPath;
            worker.FindList(selectedPath);

            // Заполнение чеклистбокса с названиями пакетов на форме
            checkedListBoxAnnotationText.Items.Clear();
            checkedListBoxAnnotationText.Items.AddRange(worker.GetContentTitleText());

            if (checkedListBoxAnnotationText.Items.Count < 3)
            {
                for (int i = 0; i < checkedListBoxAnnotationText.Items.Count; i++)
                {
                    checkedListBoxAnnotationText.SetItemChecked(i, true);
                }
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
