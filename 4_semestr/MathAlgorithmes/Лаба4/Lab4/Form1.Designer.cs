namespace Lab4
{
    partial class Form1
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
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.nLabel = new System.Windows.Forms.Label();
            this.mLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nTextBox
            // 
            this.nTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nTextBox.Location = new System.Drawing.Point(10, 57);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(100, 26);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.Text = "5";
            // 
            // mTextBox
            // 
            this.mTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mTextBox.Location = new System.Drawing.Point(126, 57);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(100, 26);
            this.mTextBox.TabIndex = 1;
            this.mTextBox.Text = "9";
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(12, 104);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(214, 50);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Сгенерировать граф";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel.Location = new System.Drawing.Point(12, 34);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(80, 20);
            this.nLabel.TabIndex = 3;
            this.nLabel.Text = "Вершины";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mLabel.Location = new System.Drawing.Point(131, 34);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(44, 20);
            this.mLabel.TabIndex = 4;
            this.mLabel.Text = "Дуги";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 172);
            this.Controls.Add(this.mLabel);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mTextBox);
            this.Controls.Add(this.nTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Label mLabel;
    }
}

