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
                    // Внесение адреса выбранной папки в поле на форке 
                    labelPath.Text = fbd.SelectedPath;
                    worker.FindList(fbd.SelectedPath);

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

                // Передача рабочему классу списка контента, которій вібрал пользователь
                worker.SetSelectedItems(selectedItems.ToArray());

                // Запуск фоновой работы
                backgroundWorker.RunWorkerAsync();

                // Активация прогрессбара
                progressBar.MarqueeAnimationSpeed = 50;
                progressBar.Visible = true;
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

            e.Result = worker.CheckFiles();
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

                // Останова прогрессбара
                progressBar.Visible = false;
                progressBar.MarqueeAnimationSpeed = 0;
            }
        }
    }
}
