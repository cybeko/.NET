namespace proj_BannedWordsSearch
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonEnterWord = new Button();
            textBoxBannedWord = new TextBox();
            listBoxBannedWords = new ListBox();
            buttonStart = new Button();
            textBoxReportDir = new TextBox();
            buttonSelectReportDir = new Button();
            labelStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // buttonEnterWord
            // 
            buttonEnterWord.Location = new Point(337, 43);
            buttonEnterWord.Name = "buttonEnterWord";
            buttonEnterWord.Size = new Size(75, 23);
            buttonEnterWord.TabIndex = 0;
            buttonEnterWord.Text = "Enter";
            buttonEnterWord.UseVisualStyleBackColor = true;
            buttonEnterWord.Click += buttonEnterWord_Click;
            // 
            // textBoxBannedWord
            // 
            textBoxBannedWord.Location = new Point(212, 43);
            textBoxBannedWord.Name = "textBoxBannedWord";
            textBoxBannedWord.Size = new Size(119, 23);
            textBoxBannedWord.TabIndex = 1;
            // 
            // listBoxBannedWords
            // 
            listBoxBannedWords.FormattingEnabled = true;
            listBoxBannedWords.ItemHeight = 15;
            listBoxBannedWords.Location = new Point(12, 28);
            listBoxBannedWords.Name = "listBoxBannedWords";
            listBoxBannedWords.Size = new Size(174, 229);
            listBoxBannedWords.TabIndex = 2;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(55, 263);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxReportDir
            // 
            textBoxReportDir.Location = new Point(212, 99);
            textBoxReportDir.Name = "textBoxReportDir";
            textBoxReportDir.Size = new Size(119, 23);
            textBoxReportDir.TabIndex = 4;
            // 
            // buttonSelectReportDir
            // 
            buttonSelectReportDir.Location = new Point(337, 99);
            buttonSelectReportDir.Name = "buttonSelectReportDir";
            buttonSelectReportDir.Size = new Size(75, 23);
            buttonSelectReportDir.TabIndex = 5;
            buttonSelectReportDir.Text = "Select...";
            buttonSelectReportDir.UseVisualStyleBackColor = true;
            buttonSelectReportDir.Click += buttonSelectReportDir_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(12, 10);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(151, 15);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Double click to delete word";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 25);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 7;
            label1.Text = "Word";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 81);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 8;
            label2.Text = "Select Dest. Folder";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 298);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelStatus);
            Controls.Add(buttonSelectReportDir);
            Controls.Add(textBoxReportDir);
            Controls.Add(buttonStart);
            Controls.Add(listBoxBannedWords);
            Controls.Add(textBoxBannedWord);
            Controls.Add(buttonEnterWord);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEnterWord;
        private TextBox textBoxBannedWord;
        private ListBox listBoxBannedWords;
        private Button buttonStart;
        private TextBox textBoxReportDir;
        private Button buttonSelectReportDir;
        private Label labelStatus;
        private Label label1;
        private Label label2;
    }
}
