namespace hw34
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
            textBoxName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxAge = new TextBox();
            textBoxGroup = new TextBox();
            buttonAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listBox = new ListBox();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(42, 53);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(199, 23);
            textBoxName.TabIndex = 0;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(42, 113);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(199, 23);
            textBoxLastName.TabIndex = 0;
            // 
            // textBoxAge
            // 
            textBoxAge.Location = new Point(42, 180);
            textBoxAge.Name = "textBoxAge";
            textBoxAge.Size = new Size(199, 23);
            textBoxAge.TabIndex = 0;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(42, 244);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(199, 23);
            textBoxGroup.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(96, 286);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 32);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 89);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 162);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 3;
            label3.Text = "Age";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 226);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 3;
            label4.Text = "Group";
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new Point(279, 53);
            listBox.Name = "listBox";
            listBox.Size = new Size(253, 364);
            listBox.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonAdd);
            Controls.Add(listBox);
            Controls.Add(textBoxGroup);
            Controls.Add(textBoxAge);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxLastName;
        private TextBox textBoxAge;
        private TextBox textBoxGroup;
        private Button buttonAdd;
        private ListBox listBox;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
