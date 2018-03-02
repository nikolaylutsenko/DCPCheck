using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckDCP
{
    public partial class helpwindow : Form
    {
        public helpwindow()
        {
            InitializeComponent();
        }

        private void helpwindow_Load(object sender, EventArgs e)
        {
            // richTextBox1.Text = "Hello!";
            richTextBox1.Text = "\tИнструкция по использованию программы: \n \t 1.В верхнем левом углу нажмите кнопку \"Выбрать папку\". Появится окно выбора папки. В нем указать место рассположения пакета для проверки(можно выбрать директорию в которой содержится множество DCP пакетов). \n \t 2.В правой части выделить галочкой необходимые для проверки пакеты (если необходимо выбрать все пакеты можно выделить их при помощи галочки \"Выделить все\" внизу слева. \n \t 3.Внизу слева нажать кнопку проверить. Дождаться завершения работы программы. \n \t 4.По завершению работы программы прозвучит звуковое оповещение и появится диалоговое окно с надписью \"Проверка успешно завершена\". \n \t 5.Результат проверки отображается в правой части окна программы. \n \t 6.Если файл отсутствует или не соответствует по характеристикам ошибка будет подсвечена красным цветом. \n \t 7.Вывод работы анализа DCP пакета можно скопировать в буфер обмена при момощи кнопки \"Копировать в буфер\".";
        }

        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
