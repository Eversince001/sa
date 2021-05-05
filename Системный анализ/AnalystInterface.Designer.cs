namespace Системный_анализ
{
    partial class AnalystInterface
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
            this.Data = new System.Windows.Forms.DataGridView();
            this.ExpertList = new System.Windows.Forms.Button();
            this.ExpertListBack = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.BackFromResultsshow = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.archive = new System.Windows.Forms.DataGridView();
            this.ArchiveButton = new System.Windows.Forms.Button();
            this.BackArchiveButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackButton.Location = new System.Drawing.Point(12, 628);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(222, 49);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Назад в меню";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Data
            // 
            this.Data.BackgroundColor = System.Drawing.Color.White;
            this.Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Location = new System.Drawing.Point(6, 3);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(1119, 539);
            this.Data.TabIndex = 2;
            // 
            // ExpertList
            // 
            this.ExpertList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExpertList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExpertList.Location = new System.Drawing.Point(896, 628);
            this.ExpertList.Name = "ExpertList";
            this.ExpertList.Size = new System.Drawing.Size(222, 49);
            this.ExpertList.TabIndex = 3;
            this.ExpertList.Text = "Список всех экспертов";
            this.ExpertList.UseVisualStyleBackColor = true;
            this.ExpertList.Click += new System.EventHandler(this.ExpertList_Click);
            // 
            // ExpertListBack
            // 
            this.ExpertListBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExpertListBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExpertListBack.Location = new System.Drawing.Point(460, 628);
            this.ExpertListBack.Name = "ExpertListBack";
            this.ExpertListBack.Size = new System.Drawing.Size(222, 49);
            this.ExpertListBack.TabIndex = 4;
            this.ExpertListBack.Text = "Назад к списку проблем";
            this.ExpertListBack.UseVisualStyleBackColor = true;
            this.ExpertListBack.Visible = false;
            this.ExpertListBack.Click += new System.EventHandler(this.ExpertListBack_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1119, 539);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.Visible = false;
            // 
            // BackFromResultsshow
            // 
            this.BackFromResultsshow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackFromResultsshow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackFromResultsshow.Location = new System.Drawing.Point(12, 628);
            this.BackFromResultsshow.Name = "BackFromResultsshow";
            this.BackFromResultsshow.Size = new System.Drawing.Size(222, 49);
            this.BackFromResultsshow.TabIndex = 7;
            this.BackFromResultsshow.Text = "Назад к списку экспертов";
            this.BackFromResultsshow.UseVisualStyleBackColor = true;
            this.BackFromResultsshow.Visible = false;
            this.BackFromResultsshow.Click += new System.EventHandler(this.BackFromResultsshow_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Location = new System.Drawing.Point(6, 3);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(1119, 539);
            this.dataGridViewResults.TabIndex = 8;
            this.dataGridViewResults.Visible = false;
            // 
            // archive
            // 
            this.archive.BackgroundColor = System.Drawing.Color.White;
            this.archive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.archive.Location = new System.Drawing.Point(6, 3);
            this.archive.Name = "archive";
            this.archive.Size = new System.Drawing.Size(1118, 538);
            this.archive.TabIndex = 9;
            // 
            // ArchiveButton
            // 
            this.ArchiveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ArchiveButton.Location = new System.Drawing.Point(460, 628);
            this.ArchiveButton.Name = "ArchiveButton";
            this.ArchiveButton.Size = new System.Drawing.Size(222, 49);
            this.ArchiveButton.TabIndex = 10;
            this.ArchiveButton.Text = "Список решенных проблем";
            this.ArchiveButton.UseVisualStyleBackColor = true;
            this.ArchiveButton.Click += new System.EventHandler(this.ArchiveButton_Click);
            // 
            // BackArchiveButton
            // 
            this.BackArchiveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackArchiveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackArchiveButton.Location = new System.Drawing.Point(460, 628);
            this.BackArchiveButton.Name = "BackArchiveButton";
            this.BackArchiveButton.Size = new System.Drawing.Size(222, 49);
            this.BackArchiveButton.TabIndex = 11;
            this.BackArchiveButton.Text = "Назад к списку проблем";
            this.BackArchiveButton.UseVisualStyleBackColor = true;
            this.BackArchiveButton.Visible = false;
            this.BackArchiveButton.Click += new System.EventHandler(this.BackArchiveButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(896, 573);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(222, 49);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Сохранить все данные в файл";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // AnalystInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1130, 702);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BackArchiveButton);
            this.Controls.Add(this.ArchiveButton);
            this.Controls.Add(this.archive);
            this.Controls.Add(this.dataGridViewResults);
            this.Controls.Add(this.BackFromResultsshow);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.ExpertListBack);
            this.Controls.Add(this.ExpertList);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.BackButton);
            this.Name = "AnalystInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интерфейс аналитика:";
            this.Load += new System.EventHandler(this.AnalystInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.archive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView Data;
        private System.Windows.Forms.Button ExpertList;
        private System.Windows.Forms.Button ExpertListBack;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button BackFromResultsshow;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridView archive;
        private System.Windows.Forms.Button ArchiveButton;
        private System.Windows.Forms.Button BackArchiveButton;
        private System.Windows.Forms.Button SaveButton;
    }
}