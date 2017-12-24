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
    public partial class Form1 : Form
    {
        Worker worker = new Worker();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    label1.Text =  worker.SetFolderName(fbd.SelectedPath);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            worker.GetFileNameWithPKL();
            richTextBox1.Lines = worker.ShowAllFileWithPKL();
            richTextBox2.Lines = worker.GetFileList();
        }
    }
}
