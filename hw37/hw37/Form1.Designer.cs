namespace hw37
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
            this.listBoxRunning = new System.Windows.Forms.ListBox();
            this.listBoxWaiting = new System.Windows.Forms.ListBox();
            this.listBoxCreated = new System.Windows.Forms.ListBox();
            this.textBoxSemaphoreSpaceAvailable = new System.Windows.Forms.TextBox();
            this.buttonCreateThread = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxRunning
            // 
            this.listBoxRunning.FormattingEnabled = true;
            this.listBoxRunning.Location = new System.Drawing.Point(12, 42);
            this.listBoxRunning.Name = "listBoxRunning";
            this.listBoxRunning.Size = new System.Drawing.Size(120, 95);
            this.listBoxRunning.TabIndex = 0;
            // 
            // listBoxWaiting
            // 
            this.listBoxWaiting.FormattingEnabled = true;
            this.listBoxWaiting.Location = new System.Drawing.Point(138, 42);
            this.listBoxWaiting.Name = "listBoxWaiting";
            this.listBoxWaiting.Size = new System.Drawing.Size(120, 95);
            this.listBoxWaiting.TabIndex = 1;
            // 
            // listBoxCreated
            // 
            this.listBoxCreated.FormattingEnabled = true;
            this.listBoxCreated.Location = new System.Drawing.Point(264, 42);
            this.listBoxCreated.Name = "listBoxCreated";
            this.listBoxCreated.Size = new System.Drawing.Size(120, 95);
            this.listBoxCreated.TabIndex = 2;
            // 
            // textBoxSemaphoreSpaceAvailable
            // 
            this.textBoxSemaphoreSpaceAvailable.Location = new System.Drawing.Point(11, 167);
            this.textBoxSemaphoreSpaceAvailable.Name = "textBoxSemaphoreSpaceAvailable";
            this.textBoxSemaphoreSpaceAvailable.Size = new System.Drawing.Size(100, 20);
            this.textBoxSemaphoreSpaceAvailable.TabIndex = 3;
            // 
            // buttonCreateThread
            // 
            this.buttonCreateThread.Location = new System.Drawing.Point(117, 165);
            this.buttonCreateThread.Name = "buttonCreateThread";
            this.buttonCreateThread.Size = new System.Drawing.Size(98, 23);
            this.buttonCreateThread.TabIndex = 4;
            this.buttonCreateThread.Text = "Create Thread";
            this.buttonCreateThread.UseVisualStyleBackColor = true;
            this.buttonCreateThread.Click += new System.EventHandler(this.buttonCreateThread_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Semaphore spaces";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Running";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Waiting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Created";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 227);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateThread);
            this.Controls.Add(this.textBoxSemaphoreSpaceAvailable);
            this.Controls.Add(this.listBoxCreated);
            this.Controls.Add(this.listBoxWaiting);
            this.Controls.Add(this.listBoxRunning);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRunning;
        private System.Windows.Forms.ListBox listBoxWaiting;
        private System.Windows.Forms.ListBox listBoxCreated;
        private System.Windows.Forms.TextBox textBoxSemaphoreSpaceAvailable;
        private System.Windows.Forms.Button buttonCreateThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

