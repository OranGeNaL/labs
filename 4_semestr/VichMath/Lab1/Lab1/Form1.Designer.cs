namespace Lab1
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
            this.halfDivide = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SimpleIterations = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // halfDivide
            // 
            this.halfDivide.Location = new System.Drawing.Point(12, 32);
            this.halfDivide.Name = "halfDivide";
            this.halfDivide.Size = new System.Drawing.Size(85, 39);
            this.halfDivide.TabIndex = 0;
            this.halfDivide.Text = "Половинное деление";
            this.halfDivide.UseVisualStyleBackColor = true;
            this.halfDivide.Click += new System.EventHandler(this.halfDivide_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Хорды и касательные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SimpleIterations
            // 
            this.SimpleIterations.Location = new System.Drawing.Point(229, 32);
            this.SimpleIterations.Name = "SimpleIterations";
            this.SimpleIterations.Size = new System.Drawing.Size(85, 39);
            this.SimpleIterations.TabIndex = 2;
            this.SimpleIterations.Text = "Простые итерации";
            this.SimpleIterations.UseVisualStyleBackColor = true;
            this.SimpleIterations.Click += new System.EventHandler(this.SimpleIterations_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 95);
            this.Controls.Add(this.SimpleIterations);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.halfDivide);
            this.Name = "Form1";
            this.Text = "Вычислительная математика";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button halfDivide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SimpleIterations;
    }
}

