namespace hw31
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
            textBoxMask = new TextBox();
            textBoxPhrase = new TextBox();
            buttonSearch = new Button();
            buttonStop = new Button();
            listView = new ListView();
            columnName = new ColumnHeader();
            columnPath = new ColumnHeader();
            labelStatus = new Label();
            SuspendLayout();
            // 
            // textBoxMask
            // 
            textBoxMask.Location = new Point(27, 25);
            textBoxMask.Name = "textBoxMask";
            textBoxMask.Size = new Size(100, 23);
            textBoxMask.TabIndex = 0;
            // 
            // textBoxPhrase
            // 
            textBoxPhrase.Location = new Point(133, 25);
            textBoxPhrase.Name = "textBoxPhrase";
            textBoxPhrase.Size = new Size(390, 23);
            textBoxPhrase.TabIndex = 1;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(529, 25);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(75, 23);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(610, 25);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 3;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // listView
            // 
            listView.Columns.AddRange(new ColumnHeader[] { columnName, columnPath });
            listView.Location = new Point(27, 74);
            listView.Name = "listView";
            listView.Size = new Size(658, 353);
            listView.TabIndex = 4;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            // 
            // columnName
            // 
            columnName.Width = 200;
            // 
            // columnPath
            // 
            columnPath.Text = "Path";
            columnPath.Width = 454;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(27, 9);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(64, 15);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "labelStatus";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 450);
            Controls.Add(labelStatus);
            Controls.Add(listView);
            Controls.Add(buttonStop);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxPhrase);
            Controls.Add(textBoxMask);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMask;
        private TextBox textBoxPhrase;
        private Button buttonSearch;
        private Button buttonStop;
        private ListView listView;
        private ColumnHeader columnName;
        private ColumnHeader columnPath;
        private Label labelStatus;
    }
}
