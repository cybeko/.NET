namespace hw36
{
    partial class Form1
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
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.checkBoxSentenceCount = new System.Windows.Forms.CheckBox();
            this.checkBoxSymbolCount = new System.Windows.Forms.CheckBox();
            this.checkBoxWordCount = new System.Windows.Forms.CheckBox();
            this.checkBoxInterrogativeSentenceCount = new System.Windows.Forms.CheckBox();
            this.checkBoxExclamatorySentenceCount = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxCheckAll = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveToFile = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(12, 12);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxText.Size = new System.Drawing.Size(261, 360);
            this.textBoxText.TabIndex = 0;
            // 
            // checkBoxSentenceCount
            // 
            this.checkBoxSentenceCount.AutoSize = true;
            this.checkBoxSentenceCount.Location = new System.Drawing.Point(300, 50);
            this.checkBoxSentenceCount.Name = "checkBoxSentenceCount";
            this.checkBoxSentenceCount.Size = new System.Drawing.Size(103, 17);
            this.checkBoxSentenceCount.TabIndex = 1;
            this.checkBoxSentenceCount.Text = "Sentence Count";
            this.checkBoxSentenceCount.UseVisualStyleBackColor = true;
            // 
            // checkBoxSymbolCount
            // 
            this.checkBoxSymbolCount.AutoSize = true;
            this.checkBoxSymbolCount.Location = new System.Drawing.Point(300, 73);
            this.checkBoxSymbolCount.Name = "checkBoxSymbolCount";
            this.checkBoxSymbolCount.Size = new System.Drawing.Size(91, 17);
            this.checkBoxSymbolCount.TabIndex = 2;
            this.checkBoxSymbolCount.Text = "Symbol Count";
            this.checkBoxSymbolCount.UseVisualStyleBackColor = true;
            // 
            // checkBoxWordCount
            // 
            this.checkBoxWordCount.AutoSize = true;
            this.checkBoxWordCount.Location = new System.Drawing.Point(300, 96);
            this.checkBoxWordCount.Name = "checkBoxWordCount";
            this.checkBoxWordCount.Size = new System.Drawing.Size(104, 17);
            this.checkBoxWordCount.TabIndex = 3;
            this.checkBoxWordCount.Text = "Box Word Count";
            this.checkBoxWordCount.UseVisualStyleBackColor = true;
            // 
            // checkBoxInterrogativeSentenceCount
            // 
            this.checkBoxInterrogativeSentenceCount.AutoSize = true;
            this.checkBoxInterrogativeSentenceCount.Location = new System.Drawing.Point(300, 119);
            this.checkBoxInterrogativeSentenceCount.Name = "checkBoxInterrogativeSentenceCount";
            this.checkBoxInterrogativeSentenceCount.Size = new System.Drawing.Size(165, 17);
            this.checkBoxInterrogativeSentenceCount.TabIndex = 4;
            this.checkBoxInterrogativeSentenceCount.Text = "Interrogative Sentence Count";
            this.checkBoxInterrogativeSentenceCount.UseVisualStyleBackColor = true;
            // 
            // checkBoxExclamatorySentenceCount
            // 
            this.checkBoxExclamatorySentenceCount.AutoSize = true;
            this.checkBoxExclamatorySentenceCount.Location = new System.Drawing.Point(300, 142);
            this.checkBoxExclamatorySentenceCount.Name = "checkBoxExclamatorySentenceCount";
            this.checkBoxExclamatorySentenceCount.Size = new System.Drawing.Size(163, 17);
            this.checkBoxExclamatorySentenceCount.TabIndex = 5;
            this.checkBoxExclamatorySentenceCount.Text = "Exclamatory Sentence Count";
            this.checkBoxExclamatorySentenceCount.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(300, 176);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxCheckAll
            // 
            this.checkBoxCheckAll.AutoSize = true;
            this.checkBoxCheckAll.Location = new System.Drawing.Point(300, 27);
            this.checkBoxCheckAll.Name = "checkBoxCheckAll";
            this.checkBoxCheckAll.Size = new System.Drawing.Size(71, 17);
            this.checkBoxCheckAll.TabIndex = 8;
            this.checkBoxCheckAll.Text = "Check All";
            this.checkBoxCheckAll.UseVisualStyleBackColor = true;
            this.checkBoxCheckAll.CheckedChanged += new System.EventHandler(this.checkBoxCheckAll_CheckedChanged);
            // 
            // checkBoxSaveToFile
            // 
            this.checkBoxSaveToFile.AutoSize = true;
            this.checkBoxSaveToFile.Location = new System.Drawing.Point(300, 220);
            this.checkBoxSaveToFile.Name = "checkBoxSaveToFile";
            this.checkBoxSaveToFile.Size = new System.Drawing.Size(121, 17);
            this.checkBoxSaveToFile.TabIndex = 9;
            this.checkBoxSaveToFile.Text = "Save Report To File";
            this.checkBoxSaveToFile.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(381, 176);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 383);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.checkBoxSaveToFile);
            this.Controls.Add(this.checkBoxCheckAll);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.checkBoxExclamatorySentenceCount);
            this.Controls.Add(this.checkBoxInterrogativeSentenceCount);
            this.Controls.Add(this.checkBoxWordCount);
            this.Controls.Add(this.checkBoxSymbolCount);
            this.Controls.Add(this.checkBoxSentenceCount);
            this.Controls.Add(this.textBoxText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.CheckBox checkBoxSentenceCount;
        private System.Windows.Forms.CheckBox checkBoxSymbolCount;
        private System.Windows.Forms.CheckBox checkBoxWordCount;
        private System.Windows.Forms.CheckBox checkBoxInterrogativeSentenceCount;
        private System.Windows.Forms.CheckBox checkBoxExclamatorySentenceCount;
        private System.Windows.Forms.CheckBox checkBoxCheckAll;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox checkBoxSaveToFile;
        private System.Windows.Forms.Button buttonClear;
    }
}

