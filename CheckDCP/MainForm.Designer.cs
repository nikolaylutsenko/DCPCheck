namespace CheckDCP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectPath = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.richTextBoxHashCheckResult = new System.Windows.Forms.RichTextBox();
            this.checkHash = new System.Windows.Forms.Button();
            this.labelPathInfo = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemManualFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectPath
            // 
            this.selectPath.Location = new System.Drawing.Point(12, 27);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(156, 23);
            this.selectPath.TabIndex = 0;
            this.selectPath.Text = "Выбрать папку";
            this.selectPath.UseVisualStyleBackColor = true;
            this.selectPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(174, 32);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(23, 13);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "D:\\";
            // 
            // richTextBoxHashCheckResult
            // 
            this.richTextBoxHashCheckResult.Location = new System.Drawing.Point(12, 85);
            this.richTextBoxHashCheckResult.Name = "richTextBoxHashCheckResult";
            this.richTextBoxHashCheckResult.Size = new System.Drawing.Size(984, 126);
            this.richTextBoxHashCheckResult.TabIndex = 2;
            this.richTextBoxHashCheckResult.Text = "";
            // 
            // checkHash
            // 
            this.checkHash.Location = new System.Drawing.Point(12, 56);
            this.checkHash.Name = "checkHash";
            this.checkHash.Size = new System.Drawing.Size(156, 23);
            this.checkHash.TabIndex = 3;
            this.checkHash.Text = "Проверить";
            this.checkHash.UseVisualStyleBackColor = true;
            this.checkHash.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelPathInfo
            // 
            this.labelPathInfo.AutoSize = true;
            this.labelPathInfo.Location = new System.Drawing.Point(174, 61);
            this.labelPathInfo.Name = "labelPathInfo";
            this.labelPathInfo.Size = new System.Drawing.Size(57, 13);
            this.labelPathInfo.TabIndex = 4;
            this.labelPathInfo.Text = "Проверка";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 243);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(984, 196);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.настройкиToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemManualFolder,
            this.menuItemExit});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // menuItemManualFolder
            // 
            this.menuItemManualFolder.Name = "menuItemManualFolder";
            this.menuItemManualFolder.Size = new System.Drawing.Size(233, 22);
            this.menuItemManualFolder.Text = "Ввести адрес папки вручную";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(233, 22);
            this.menuItemExit.Text = "Выход";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 477);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.labelPathInfo);
            this.Controls.Add(this.checkHash);
            this.Controls.Add(this.richTextBoxHashCheckResult);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.RichTextBox richTextBoxHashCheckResult;
        private System.Windows.Forms.Button checkHash;
        private System.Windows.Forms.Label labelPathInfo;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemManualFolder;
    }
}

