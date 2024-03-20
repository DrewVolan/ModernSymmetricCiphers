namespace ModernSymmetricCiphers.Forms
{
    partial class MainForm
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
            this.encoderPanel = new System.Windows.Forms.Panel();
            this.decodeButton = new System.Windows.Forms.Button();
            this.encodeButton = new System.Windows.Forms.Button();
            this.secretKeyTextBox = new System.Windows.Forms.TextBox();
            this.secretKeyLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.encoderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // encoderPanel
            // 
            this.encoderPanel.Controls.Add(this.decodeButton);
            this.encoderPanel.Controls.Add(this.encodeButton);
            this.encoderPanel.Controls.Add(this.secretKeyTextBox);
            this.encoderPanel.Controls.Add(this.secretKeyLabel);
            this.encoderPanel.Controls.Add(this.pathLabel);
            this.encoderPanel.Controls.Add(this.pathButton);
            this.encoderPanel.Controls.Add(this.pathTextBox);
            this.encoderPanel.Location = new System.Drawing.Point(12, 12);
            this.encoderPanel.Name = "encoderPanel";
            this.encoderPanel.Size = new System.Drawing.Size(1234, 640);
            this.encoderPanel.TabIndex = 0;
            // 
            // decodeButton
            // 
            this.decodeButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decodeButton.Location = new System.Drawing.Point(1016, 544);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(200, 80);
            this.decodeButton.TabIndex = 7;
            this.decodeButton.Text = "Расшифровать файл";
            this.decodeButton.UseVisualStyleBackColor = true;
            // 
            // encodeButton
            // 
            this.encodeButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodeButton.Location = new System.Drawing.Point(810, 544);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(200, 80);
            this.encodeButton.TabIndex = 6;
            this.encodeButton.Text = "Зашифровать файл";
            this.encodeButton.UseVisualStyleBackColor = true;
            // 
            // secretKeyTextBox
            // 
            this.secretKeyTextBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secretKeyTextBox.Location = new System.Drawing.Point(246, 155);
            this.secretKeyTextBox.Name = "secretKeyTextBox";
            this.secretKeyTextBox.Size = new System.Drawing.Size(764, 40);
            this.secretKeyTextBox.TabIndex = 5;
            // 
            // secretKeyLabel
            // 
            this.secretKeyLabel.AutoSize = true;
            this.secretKeyLabel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secretKeyLabel.Location = new System.Drawing.Point(16, 155);
            this.secretKeyLabel.Name = "secretKeyLabel";
            this.secretKeyLabel.Size = new System.Drawing.Size(224, 33);
            this.secretKeyLabel.TabIndex = 4;
            this.secretKeyLabel.Text = "Секретный ключ:";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathLabel.Location = new System.Drawing.Point(16, 16);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(180, 33);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "Путь к файлу:";
            // 
            // pathButton
            // 
            this.pathButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathButton.Location = new System.Drawing.Point(1016, 16);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(200, 80);
            this.pathButton.TabIndex = 3;
            this.pathButton.Text = "Загрузить файл";
            this.pathButton.UseVisualStyleBackColor = true;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathTextBox.Location = new System.Drawing.Point(202, 16);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(808, 40);
            this.pathTextBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.encoderPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шифратор";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.encoderPanel.ResumeLayout(false);
            this.encoderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel encoderPanel;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox secretKeyTextBox;
        private System.Windows.Forms.Label secretKeyLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.Button encodeButton;
    }
}

