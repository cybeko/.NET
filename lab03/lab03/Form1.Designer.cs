namespace lab03
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
            progressBar1 = new ProgressBar();
            buttonStart = new Button();
            progressBar2 = new ProgressBar();
            progressBar3 = new ProgressBar();
            progressBar4 = new ProgressBar();
            progressBar5 = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(37, 81);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(255, 23);
            progressBar1.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(126, 36);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(37, 128);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(255, 23);
            progressBar2.TabIndex = 0;
            // 
            // progressBar3
            // 
            progressBar3.Location = new Point(37, 176);
            progressBar3.Name = "progressBar3";
            progressBar3.Size = new Size(255, 23);
            progressBar3.TabIndex = 0;
            // 
            // progressBar4
            // 
            progressBar4.Location = new Point(37, 220);
            progressBar4.Name = "progressBar4";
            progressBar4.Size = new Size(255, 23);
            progressBar4.TabIndex = 0;
            // 
            // progressBar5
            // 
            progressBar5.Location = new Point(37, 269);
            progressBar5.Name = "progressBar5";
            progressBar5.Size = new Size(255, 23);
            progressBar5.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 340);
            Controls.Add(buttonStart);
            Controls.Add(progressBar5);
            Controls.Add(progressBar4);
            Controls.Add(progressBar3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Button buttonStart;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private ProgressBar progressBar3;
        private ProgressBar progressBar4;
        private ProgressBar progressBar5;
    }
}
