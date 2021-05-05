namespace Системный_анализ
{
    partial class ProblemEdit
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
            this.BackButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataSolutions = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataCurrentExperts = new System.Windows.Forms.DataGridView();
            this.EditorBackButton = new System.Windows.Forms.Button();
            this.DataExperts = new System.Windows.Forms.DataGridView();
            this.AddExpertButton = new System.Windows.Forms.Button();
            this.ProblemTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BackEditorButton = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ResultsView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.PersResultsView = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.ProblemSolvedButton = new System.Windows.Forms.Button();
            this.RedoProblemButton = new System.Windows.Forms.Button();
            this.ResultsArchButton = new System.Windows.Forms.Button();
            this.AltrListButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AResultsView = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSolutions)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataCurrentExperts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataExperts)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersResultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AResultsView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(12, 773);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(225, 43);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Назад к списку проблем";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 251);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 517);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataSolutions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Альтернативы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DataSolutions
            // 
            this.DataSolutions.BackgroundColor = System.Drawing.Color.White;
            this.DataSolutions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataSolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataSolutions.Location = new System.Drawing.Point(11, 10);
            this.DataSolutions.Name = "DataSolutions";
            this.DataSolutions.Size = new System.Drawing.Size(1081, 474);
            this.DataSolutions.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DataCurrentExperts);
            this.tabPage2.Controls.Add(this.EditorBackButton);
            this.tabPage2.Controls.Add(this.DataExperts);
            this.tabPage2.Controls.Add(this.AddExpertButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Эксперты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataCurrentExperts
            // 
            this.DataCurrentExperts.BackgroundColor = System.Drawing.Color.White;
            this.DataCurrentExperts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataCurrentExperts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataCurrentExperts.Location = new System.Drawing.Point(11, 55);
            this.DataCurrentExperts.Name = "DataCurrentExperts";
            this.DataCurrentExperts.Size = new System.Drawing.Size(1081, 429);
            this.DataCurrentExperts.TabIndex = 15;
            // 
            // EditorBackButton
            // 
            this.EditorBackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditorBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditorBackButton.Location = new System.Drawing.Point(9, 7);
            this.EditorBackButton.Name = "EditorBackButton";
            this.EditorBackButton.Size = new System.Drawing.Size(225, 43);
            this.EditorBackButton.TabIndex = 14;
            this.EditorBackButton.Text = "Назад к редактору проблемы";
            this.EditorBackButton.UseVisualStyleBackColor = true;
            this.EditorBackButton.Visible = false;
            this.EditorBackButton.Click += new System.EventHandler(this.EditorBackButton_Click);
            // 
            // DataExperts
            // 
            this.DataExperts.BackgroundColor = System.Drawing.Color.White;
            this.DataExperts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataExperts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataExperts.Location = new System.Drawing.Point(9, 55);
            this.DataExperts.Name = "DataExperts";
            this.DataExperts.Size = new System.Drawing.Size(1081, 429);
            this.DataExperts.TabIndex = 1;
            this.DataExperts.Visible = false;
            // 
            // AddExpertButton
            // 
            this.AddExpertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddExpertButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddExpertButton.Location = new System.Drawing.Point(869, 7);
            this.AddExpertButton.Name = "AddExpertButton";
            this.AddExpertButton.Size = new System.Drawing.Size(225, 43);
            this.AddExpertButton.TabIndex = 11;
            this.AddExpertButton.Text = "Выбрать эксперта из общего списка";
            this.AddExpertButton.UseVisualStyleBackColor = true;
            this.AddExpertButton.Click += new System.EventHandler(this.AddExpertButton_Click);
            // 
            // ProblemTextBox
            // 
            this.ProblemTextBox.Location = new System.Drawing.Point(11, 33);
            this.ProblemTextBox.Multiline = true;
            this.ProblemTextBox.Name = "ProblemTextBox";
            this.ProblemTextBox.Size = new System.Drawing.Size(1106, 208);
            this.ProblemTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(428, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Форумлировка проблемы";
            // 
            // BackEditorButton
            // 
            this.BackEditorButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackEditorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackEditorButton.Location = new System.Drawing.Point(12, 774);
            this.BackEditorButton.Name = "BackEditorButton";
            this.BackEditorButton.Size = new System.Drawing.Size(225, 43);
            this.BackEditorButton.TabIndex = 8;
            this.BackEditorButton.Text = "Назад к редактору проблемы";
            this.BackEditorButton.UseVisualStyleBackColor = true;
            this.BackEditorButton.Click += new System.EventHandler(this.BackEditorButton_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl2.Location = new System.Drawing.Point(12, 247);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1106, 520);
            this.tabControl2.TabIndex = 9;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ResultsView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1098, 494);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Результаты оценки";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ResultsView
            // 
            this.ResultsView.BackgroundColor = System.Drawing.Color.White;
            this.ResultsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsView.Location = new System.Drawing.Point(0, 3);
            this.ResultsView.Name = "ResultsView";
            this.ResultsView.Size = new System.Drawing.Size(1098, 491);
            this.ResultsView.TabIndex = 0;
            this.ResultsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultsView_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.PersResultsView);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1098, 494);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Оценка каждого эксперта";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // PersResultsView
            // 
            this.PersResultsView.BackgroundColor = System.Drawing.Color.White;
            this.PersResultsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PersResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersResultsView.Location = new System.Drawing.Point(6, 8);
            this.PersResultsView.Name = "PersResultsView";
            this.PersResultsView.Size = new System.Drawing.Size(1081, 480);
            this.PersResultsView.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1081, 480);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(893, 774);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "Назад ко всем оценкам";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProblemSolvedButton
            // 
            this.ProblemSolvedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProblemSolvedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProblemSolvedButton.Location = new System.Drawing.Point(431, 774);
            this.ProblemSolvedButton.Name = "ProblemSolvedButton";
            this.ProblemSolvedButton.Size = new System.Drawing.Size(225, 43);
            this.ProblemSolvedButton.TabIndex = 11;
            this.ProblemSolvedButton.Text = "Пометить проблему как решенную";
            this.ProblemSolvedButton.UseVisualStyleBackColor = true;
            this.ProblemSolvedButton.Click += new System.EventHandler(this.ProblemSolvedButton_Click);
            // 
            // RedoProblemButton
            // 
            this.RedoProblemButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RedoProblemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RedoProblemButton.Location = new System.Drawing.Point(662, 774);
            this.RedoProblemButton.Name = "RedoProblemButton";
            this.RedoProblemButton.Size = new System.Drawing.Size(225, 43);
            this.RedoProblemButton.TabIndex = 13;
            this.RedoProblemButton.Text = "Отправить проблему на доработку";
            this.RedoProblemButton.UseVisualStyleBackColor = true;
            this.RedoProblemButton.Click += new System.EventHandler(this.RedoProblemButton_Click);
            // 
            // ResultsArchButton
            // 
            this.ResultsArchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultsArchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultsArchButton.Location = new System.Drawing.Point(431, 774);
            this.ResultsArchButton.Name = "ResultsArchButton";
            this.ResultsArchButton.Size = new System.Drawing.Size(225, 43);
            this.ResultsArchButton.TabIndex = 15;
            this.ResultsArchButton.Text = "Полученные результаты";
            this.ResultsArchButton.UseVisualStyleBackColor = true;
            this.ResultsArchButton.Visible = false;
            this.ResultsArchButton.Click += new System.EventHandler(this.ResultsArchButton_Click);
            // 
            // AltrListButton
            // 
            this.AltrListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AltrListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AltrListButton.Location = new System.Drawing.Point(431, 774);
            this.AltrListButton.Name = "AltrListButton";
            this.AltrListButton.Size = new System.Drawing.Size(225, 43);
            this.AltrListButton.TabIndex = 16;
            this.AltrListButton.Text = "Список альтернатив";
            this.AltrListButton.UseVisualStyleBackColor = true;
            this.AltrListButton.Visible = false;
            this.AltrListButton.Click += new System.EventHandler(this.AltrListButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(551, 772);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(57, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(443, 774);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Размер шкалы";
            // 
            // AResultsView
            // 
            this.AResultsView.BackgroundColor = System.Drawing.Color.White;
            this.AResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AResultsView.Location = new System.Drawing.Point(12, 247);
            this.AResultsView.Name = "AResultsView";
            this.AResultsView.Size = new System.Drawing.Size(1106, 524);
            this.AResultsView.TabIndex = 1;
            // 
            // ProblemEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 829);
            this.Controls.Add(this.AResultsView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AltrListButton);
            this.Controls.Add(this.ResultsArchButton);
            this.Controls.Add(this.ProblemSolvedButton);
            this.Controls.Add(this.RedoProblemButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.BackEditorButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProblemTextBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BackButton);
            this.Name = "ProblemEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор проблемы";
            this.Load += new System.EventHandler(this.ProblemEdit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataSolutions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataCurrentExperts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataExperts)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PersResultsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AResultsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox ProblemTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataSolutions;
        private System.Windows.Forms.DataGridView DataExperts;
        private System.Windows.Forms.Button BackEditorButton;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button ProblemSolvedButton;
        private System.Windows.Forms.Button RedoProblemButton;
        private System.Windows.Forms.Button AddExpertButton;
        internal System.Windows.Forms.Button EditorBackButton;
        private System.Windows.Forms.DataGridView DataCurrentExperts;
        private System.Windows.Forms.DataGridView ResultsView;
        private System.Windows.Forms.DataGridView PersResultsView;
        private System.Windows.Forms.Button ResultsArchButton;
        private System.Windows.Forms.Button AltrListButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView AResultsView;
    }
}