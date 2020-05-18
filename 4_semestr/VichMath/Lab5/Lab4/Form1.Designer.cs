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
            this.importButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shouDotsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.countButton = new System.Windows.Forms.Button();
            this.showCouples = new System.Windows.Forms.Button();
            this.rectangleMethodButton = new System.Windows.Forms.Button();
            this.drawFuncButton = new System.Windows.Forms.Button();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxN = new System.Windows.Forms.TextBox();
            this.alable = new System.Windows.Forms.Label();
            this.blable = new System.Windows.Forms.Label();
            this.Nlabel = new System.Windows.Forms.Label();
            this.integralButton = new System.Windows.Forms.Button();
            this.simpsonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Enabled = false;
            this.importButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.importButton.Location = new System.Drawing.Point(518, 355);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(167, 37);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refreshButton.Location = new System.Drawing.Point(662, 480);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(162, 31);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Обновить форму";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(662, 426);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(162, 48);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Очистить всё";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // shouDotsButton
            // 
            this.shouDotsButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.shouDotsButton.Location = new System.Drawing.Point(543, 426);
            this.shouDotsButton.Name = "shouDotsButton";
            this.shouDotsButton.Size = new System.Drawing.Size(113, 85);
            this.shouDotsButton.TabIndex = 6;
            this.shouDotsButton.Text = "Показать координаты точек";
            this.shouDotsButton.UseVisualStyleBackColor = true;
            this.shouDotsButton.Click += new System.EventHandler(this.shouDotsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(543, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Импортируйте пары значений";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(518, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 10;
            // 
            // countButton
            // 
            this.countButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countButton.Location = new System.Drawing.Point(518, 111);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(167, 57);
            this.countButton.TabIndex = 11;
            this.countButton.Text = "Посчитать в заданной точке";
            this.countButton.UseVisualStyleBackColor = true;
            this.countButton.Click += new System.EventHandler(this.countButton_Click);
            // 
            // showCouples
            // 
            this.showCouples.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showCouples.Location = new System.Drawing.Point(518, 312);
            this.showCouples.Name = "showCouples";
            this.showCouples.Size = new System.Drawing.Size(167, 37);
            this.showCouples.TabIndex = 1;
            this.showCouples.Text = "Вывести пары";
            this.showCouples.UseVisualStyleBackColor = true;
            this.showCouples.Click += new System.EventHandler(this.showCouples_Click);
            // 
            // rectangleMethodButton
            // 
            this.rectangleMethodButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rectangleMethodButton.Location = new System.Drawing.Point(518, 237);
            this.rectangleMethodButton.Name = "rectangleMethodButton";
            this.rectangleMethodButton.Size = new System.Drawing.Size(167, 69);
            this.rectangleMethodButton.TabIndex = 12;
            this.rectangleMethodButton.Text = "Метод прямоугольников";
            this.rectangleMethodButton.UseVisualStyleBackColor = true;
            this.rectangleMethodButton.Click += new System.EventHandler(this.rectangleMethodButton_Click);
            // 
            // drawFuncButton
            // 
            this.drawFuncButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawFuncButton.Location = new System.Drawing.Point(692, 312);
            this.drawFuncButton.Name = "drawFuncButton";
            this.drawFuncButton.Size = new System.Drawing.Size(132, 80);
            this.drawFuncButton.TabIndex = 13;
            this.drawFuncButton.Text = "Построить функцию";
            this.drawFuncButton.UseVisualStyleBackColor = true;
            this.drawFuncButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(737, 173);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(34, 20);
            this.textBoxA.TabIndex = 14;
            this.textBoxA.Text = "-1";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(737, 199);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(34, 20);
            this.textBoxB.TabIndex = 15;
            this.textBoxB.Text = "1";
            // 
            // textBoxN
            // 
            this.textBoxN.Location = new System.Drawing.Point(737, 225);
            this.textBoxN.Name = "textBoxN";
            this.textBoxN.Size = new System.Drawing.Size(34, 20);
            this.textBoxN.TabIndex = 16;
            this.textBoxN.Text = "0,05";
            // 
            // alable
            // 
            this.alable.AutoSize = true;
            this.alable.Location = new System.Drawing.Point(715, 176);
            this.alable.Name = "alable";
            this.alable.Size = new System.Drawing.Size(16, 13);
            this.alable.TabIndex = 17;
            this.alable.Text = "a:";
            // 
            // blable
            // 
            this.blable.AutoSize = true;
            this.blable.Location = new System.Drawing.Point(715, 202);
            this.blable.Name = "blable";
            this.blable.Size = new System.Drawing.Size(16, 13);
            this.blable.TabIndex = 18;
            this.blable.Text = "b:";
            // 
            // Nlabel
            // 
            this.Nlabel.AutoSize = true;
            this.Nlabel.Location = new System.Drawing.Point(715, 228);
            this.Nlabel.Name = "Nlabel";
            this.Nlabel.Size = new System.Drawing.Size(18, 13);
            this.Nlabel.TabIndex = 19;
            this.Nlabel.Text = "N:";
            // 
            // integralButton
            // 
            this.integralButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.integralButton.Location = new System.Drawing.Point(692, 253);
            this.integralButton.Name = "integralButton";
            this.integralButton.Size = new System.Drawing.Size(132, 53);
            this.integralButton.TabIndex = 20;
            this.integralButton.Text = "Метод трапеций";
            this.integralButton.UseVisualStyleBackColor = true;
            this.integralButton.Click += new System.EventHandler(this.integralButton_Click);
            // 
            // simpsonButton
            // 
            this.simpsonButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpsonButton.Location = new System.Drawing.Point(518, 176);
            this.simpsonButton.Name = "simpsonButton";
            this.simpsonButton.Size = new System.Drawing.Size(167, 50);
            this.simpsonButton.TabIndex = 21;
            this.simpsonButton.Text = "Метод Симпсона";
            this.simpsonButton.UseVisualStyleBackColor = true;
            this.simpsonButton.Click += new System.EventHandler(this.simpsonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 523);
            this.Controls.Add(this.simpsonButton);
            this.Controls.Add(this.integralButton);
            this.Controls.Add(this.Nlabel);
            this.Controls.Add(this.blable);
            this.Controls.Add(this.alable);
            this.Controls.Add(this.textBoxN);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.drawFuncButton);
            this.Controls.Add(this.rectangleMethodButton);
            this.Controls.Add(this.countButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shouDotsButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showCouples);
            this.Controls.Add(this.importButton);
            this.Name = "Form1";
            this.Text = "Приближение функций";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button shouDotsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.Button showCouples;
        private System.Windows.Forms.Button rectangleMethodButton;
        private System.Windows.Forms.Button drawFuncButton;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxN;
        private System.Windows.Forms.Label alable;
        private System.Windows.Forms.Label blable;
        private System.Windows.Forms.Label Nlabel;
        private System.Windows.Forms.Button integralButton;
        private System.Windows.Forms.Button simpsonButton;
    }
}

