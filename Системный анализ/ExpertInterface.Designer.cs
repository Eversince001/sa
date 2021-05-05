namespace Системный_анализ
{
    partial class ExpertInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertInterface));
            this.BackButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ListLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.LabelBoth = new System.Windows.Forms.Label();
            this.textBoxSecond = new System.Windows.Forms.TextBox();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.EndButton = new System.Windows.Forms.Button();
            this.ProblemFormulation = new System.Windows.Forms.TextBox();
            this.WhatToDoLabel = new System.Windows.Forms.Label();
            this.SelectPage = new System.Windows.Forms.Button();
            this.PageTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.NextMethod = new System.Windows.Forms.Button();
            this.PrevMethod = new System.Windows.Forms.Button();
            this.labelmeth = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.NextButt = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(16, 704);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(149, 49);
            this.BackButton.TabIndex = 41;
            this.BackButton.Text = "Вернуться в меню";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1106, 470);
            this.listBox1.TabIndex = 44;
            // 
            // ListLabel
            // 
            this.ListLabel.AutoSize = true;
            this.ListLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListLabel.Location = new System.Drawing.Point(109, 559);
            this.ListLabel.Name = "ListLabel";
            this.ListLabel.Size = new System.Drawing.Size(0, 24);
            this.ListLabel.TabIndex = 48;
            this.ListLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 49;
            this.label2.Text = "Страница";
            this.label2.Visible = false;
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.BackColor = System.Drawing.Color.White;
            this.textBoxFirst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxFirst.Location = new System.Drawing.Point(65, 253);
            this.textBoxFirst.Multiline = true;
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.ReadOnly = true;
            this.textBoxFirst.Size = new System.Drawing.Size(434, 161);
            this.textBoxFirst.TabIndex = 66;
            // 
            // LabelBoth
            // 
            this.LabelBoth.AutoSize = true;
            this.LabelBoth.BackColor = System.Drawing.Color.White;
            this.LabelBoth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelBoth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LabelBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelBoth.Location = new System.Drawing.Point(451, 434);
            this.LabelBoth.Name = "LabelBoth";
            this.LabelBoth.Size = new System.Drawing.Size(251, 27);
            this.LabelBoth.TabIndex = 82;
            this.LabelBoth.Text = "Варианты равнозначны";
            this.LabelBoth.Visible = false;
            // 
            // textBoxSecond
            // 
            this.textBoxSecond.BackColor = System.Drawing.Color.White;
            this.textBoxSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSecond.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBoxSecond.Location = new System.Drawing.Point(640, 253);
            this.textBoxSecond.Multiline = true;
            this.textBoxSecond.Name = "textBoxSecond";
            this.textBoxSecond.ReadOnly = true;
            this.textBoxSecond.Size = new System.Drawing.Size(434, 161);
            this.textBoxSecond.TabIndex = 83;
            // 
            // PreviousButton
            // 
            this.PreviousButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PreviousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousButton.Location = new System.Drawing.Point(448, 570);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(103, 30);
            this.PreviousButton.TabIndex = 84;
            this.PreviousButton.Text = "<--";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Visible = false;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextButton.Location = new System.Drawing.Point(568, 570);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(103, 30);
            this.NextButton.TabIndex = 85;
            this.NextButton.Text = "-->";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // EndButton
            // 
            this.EndButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EndButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndButton.Location = new System.Drawing.Point(959, 704);
            this.EndButton.Name = "EndButton";
            this.EndButton.Size = new System.Drawing.Size(168, 49);
            this.EndButton.TabIndex = 86;
            this.EndButton.Text = "Завершить оценивание";
            this.EndButton.UseVisualStyleBackColor = true;
            this.EndButton.Click += new System.EventHandler(this.EndButton_Click);
            // 
            // ProblemFormulation
            // 
            this.ProblemFormulation.BackColor = System.Drawing.Color.White;
            this.ProblemFormulation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProblemFormulation.Location = new System.Drawing.Point(65, 28);
            this.ProblemFormulation.Multiline = true;
            this.ProblemFormulation.Name = "ProblemFormulation";
            this.ProblemFormulation.ReadOnly = true;
            this.ProblemFormulation.Size = new System.Drawing.Size(1009, 147);
            this.ProblemFormulation.TabIndex = 87;
            // 
            // WhatToDoLabel
            // 
            this.WhatToDoLabel.BackColor = System.Drawing.Color.White;
            this.WhatToDoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WhatToDoLabel.Location = new System.Drawing.Point(62, 178);
            this.WhatToDoLabel.Name = "WhatToDoLabel";
            this.WhatToDoLabel.Size = new System.Drawing.Size(1009, 54);
            this.WhatToDoLabel.TabIndex = 88;
            this.WhatToDoLabel.Text = resources.GetString("WhatToDoLabel.Text");
            // 
            // SelectPage
            // 
            this.SelectPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectPage.Location = new System.Drawing.Point(113, 532);
            this.SelectPage.Name = "SelectPage";
            this.SelectPage.Size = new System.Drawing.Size(105, 24);
            this.SelectPage.TabIndex = 90;
            this.SelectPage.Text = "Перейти";
            this.SelectPage.UseVisualStyleBackColor = true;
            this.SelectPage.Visible = false;
            this.SelectPage.Click += new System.EventHandler(this.SelectPage_Click);
            // 
            // PageTextBox
            // 
            this.PageTextBox.Location = new System.Drawing.Point(16, 532);
            this.PageTextBox.Multiline = true;
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.Size = new System.Drawing.Size(89, 24);
            this.PageTextBox.TabIndex = 91;
            this.PageTextBox.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 233);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1106, 269);
            this.dataGridView.TabIndex = 94;
            this.dataGridView.Visible = false;
            // 
            // NextMethod
            // 
            this.NextMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextMethod.Location = new System.Drawing.Point(568, 704);
            this.NextMethod.Name = "NextMethod";
            this.NextMethod.Size = new System.Drawing.Size(168, 49);
            this.NextMethod.TabIndex = 95;
            this.NextMethod.Text = "Следующий метод оценки";
            this.NextMethod.UseVisualStyleBackColor = true;
            this.NextMethod.Click += new System.EventHandler(this.NextMethod_Click);
            // 
            // PrevMethod
            // 
            this.PrevMethod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevMethod.Enabled = false;
            this.PrevMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrevMethod.Location = new System.Drawing.Point(383, 704);
            this.PrevMethod.Name = "PrevMethod";
            this.PrevMethod.Size = new System.Drawing.Size(168, 49);
            this.PrevMethod.TabIndex = 96;
            this.PrevMethod.Text = "Предыдущий метод оценки";
            this.PrevMethod.UseVisualStyleBackColor = true;
            this.PrevMethod.Click += new System.EventHandler(this.PrevMethod_Click);
            // 
            // labelmeth
            // 
            this.labelmeth.BackColor = System.Drawing.Color.White;
            this.labelmeth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelmeth.Location = new System.Drawing.Point(380, 505);
            this.labelmeth.Name = "labelmeth";
            this.labelmeth.Size = new System.Drawing.Size(356, 24);
            this.labelmeth.TabIndex = 97;
            this.labelmeth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelmeth.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(742, 508);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 20);
            this.numericUpDown1.TabIndex = 98;
            this.numericUpDown1.Visible = false;
            // 
            // NextButt
            // 
            this.NextButt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextButt.Location = new System.Drawing.Point(568, 570);
            this.NextButt.Name = "NextButt";
            this.NextButt.Size = new System.Drawing.Size(103, 30);
            this.NextButt.TabIndex = 99;
            this.NextButt.Text = "-->";
            this.NextButt.UseVisualStyleBackColor = true;
            this.NextButt.Visible = false;
            this.NextButt.Click += new System.EventHandler(this.NextButt_Click);
            // 
            // PrevButton
            // 
            this.PrevButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrevButton.Location = new System.Drawing.Point(448, 570);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(103, 30);
            this.PrevButton.TabIndex = 100;
            this.PrevButton.Text = "<--";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Visible = false;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // ExpertInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 765);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.NextButt);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelmeth);
            this.Controls.Add(this.PrevMethod);
            this.Controls.Add(this.NextMethod);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.PageTextBox);
            this.Controls.Add(this.SelectPage);
            this.Controls.Add(this.WhatToDoLabel);
            this.Controls.Add(this.ProblemFormulation);
            this.Controls.Add(this.EndButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.textBoxSecond);
            this.Controls.Add(this.LabelBoth);
            this.Controls.Add(this.textBoxFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.BackButton);
            this.Name = "ExpertInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.ExpertInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label ListLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.Label LabelBoth;
        private System.Windows.Forms.TextBox textBoxSecond;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button EndButton;
        private System.Windows.Forms.TextBox ProblemFormulation;
        private System.Windows.Forms.Label WhatToDoLabel;
        private System.Windows.Forms.Button SelectPage;
        private System.Windows.Forms.TextBox PageTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button NextMethod;
        private System.Windows.Forms.Button PrevMethod;
        private System.Windows.Forms.Label labelmeth;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button NextButt;
        private System.Windows.Forms.Button PrevButton;
    }
}