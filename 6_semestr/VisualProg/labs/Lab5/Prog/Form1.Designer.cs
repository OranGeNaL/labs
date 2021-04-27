
namespace Prog
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.encriptButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.decriptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 143);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Тут будет немного стандартного текста для проверки. Люблю пельмени.";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // encriptButton
            // 
            this.encriptButton.Location = new System.Drawing.Point(21, 179);
            this.encriptButton.Name = "encriptButton";
            this.encriptButton.Size = new System.Drawing.Size(253, 23);
            this.encriptButton.TabIndex = 1;
            this.encriptButton.Text = "Зашифровать";
            this.encriptButton.UseVisualStyleBackColor = true;
            this.encriptButton.Click += new System.EventHandler(this.encriptButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(280, 30);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(253, 143);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Здесь результат...";
            // 
            // decriptButton
            // 
            this.decriptButton.Location = new System.Drawing.Point(280, 179);
            this.decriptButton.Name = "decriptButton";
            this.decriptButton.Size = new System.Drawing.Size(253, 23);
            this.decriptButton.TabIndex = 1;
            this.decriptButton.Text = "Расшифровать";
            this.decriptButton.UseVisualStyleBackColor = true;
            this.decriptButton.Click += new System.EventHandler(this.decriptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 224);
            this.Controls.Add(this.decriptButton);
            this.Controls.Add(this.encriptButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Encriptor/Decriptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button encriptButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button decriptButton;
    }
}

