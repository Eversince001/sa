namespace Системный_анализ
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AnalystInterfaceButton = new System.Windows.Forms.Button();
            this.InterfaceChoiceLabel = new System.Windows.Forms.Label();
            this.ExpertInterfaceButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AnalystInterfaceButton
            // 
            this.AnalystInterfaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnalystInterfaceButton.Location = new System.Drawing.Point(327, 193);
            this.AnalystInterfaceButton.Name = "AnalystInterfaceButton";
            this.AnalystInterfaceButton.Size = new System.Drawing.Size(238, 49);
            this.AnalystInterfaceButton.TabIndex = 0;
            this.AnalystInterfaceButton.Text = "Интерфейс аналитика";
            this.AnalystInterfaceButton.UseVisualStyleBackColor = true;
            this.AnalystInterfaceButton.Click += new System.EventHandler(this.AnalystInterfaceButton_Click);
            // 
            // InterfaceChoiceLabel
            // 
            this.InterfaceChoiceLabel.AutoSize = true;
            this.InterfaceChoiceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InterfaceChoiceLabel.Location = new System.Drawing.Point(342, 155);
            this.InterfaceChoiceLabel.Name = "InterfaceChoiceLabel";
            this.InterfaceChoiceLabel.Size = new System.Drawing.Size(205, 24);
            this.InterfaceChoiceLabel.TabIndex = 2;
            this.InterfaceChoiceLabel.Text = "Выберите интерфейс";
            // 
            // ExpertInterfaceButton
            // 
            this.ExpertInterfaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExpertInterfaceButton.Location = new System.Drawing.Point(327, 248);
            this.ExpertInterfaceButton.Name = "ExpertInterfaceButton";
            this.ExpertInterfaceButton.Size = new System.Drawing.Size(238, 49);
            this.ExpertInterfaceButton.TabIndex = 3;
            this.ExpertInterfaceButton.Text = "Интерфейс эксперта";
            this.ExpertInterfaceButton.UseVisualStyleBackColor = true;
            this.ExpertInterfaceButton.Click += new System.EventHandler(this.ExpertInterfaceButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(376, 463);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(108, 37);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(863, 512);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ExpertInterfaceButton);
            this.Controls.Add(this.InterfaceChoiceLabel);
            this.Controls.Add(this.AnalystInterfaceButton);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AnalystInterfaceButton;
        private System.Windows.Forms.Label InterfaceChoiceLabel;
        private System.Windows.Forms.Button ExpertInterfaceButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

