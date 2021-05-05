namespace Системный_анализ
{
    partial class editformulation
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
            this.FormulationTextBox = new System.Windows.Forms.TextBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.SaveformulationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormulationTextBox
            // 
            this.FormulationTextBox.Location = new System.Drawing.Point(12, 12);
            this.FormulationTextBox.Multiline = true;
            this.FormulationTextBox.Name = "FormulationTextBox";
            this.FormulationTextBox.Size = new System.Drawing.Size(776, 329);
            this.FormulationTextBox.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 396);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(157, 42);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Назад к альтернативам";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // SaveformulationButton
            // 
            this.SaveformulationButton.Location = new System.Drawing.Point(326, 396);
            this.SaveformulationButton.Name = "SaveformulationButton";
            this.SaveformulationButton.Size = new System.Drawing.Size(119, 42);
            this.SaveformulationButton.TabIndex = 2;
            this.SaveformulationButton.Text = "Сохранить";
            this.SaveformulationButton.UseVisualStyleBackColor = true;
            this.SaveformulationButton.Click += new System.EventHandler(this.SaveformulationButton_Click);
            // 
            // editformulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveformulationButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FormulationTextBox);
            this.Name = "editformulation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формулировка альтернативы";
            this.Load += new System.EventHandler(this.editformulation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FormulationTextBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SaveformulationButton;
    }
}