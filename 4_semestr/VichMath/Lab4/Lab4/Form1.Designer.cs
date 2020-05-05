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
            this.showCouples = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.lessQuadsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.shouDotsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.importButton.Location = new System.Drawing.Point(543, 355);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(142, 37);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // showCouples
            // 
            this.showCouples.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showCouples.Location = new System.Drawing.Point(543, 312);
            this.showCouples.Name = "showCouples";
            this.showCouples.Size = new System.Drawing.Size(142, 37);
            this.showCouples.TabIndex = 1;
            this.showCouples.Text = "Вывести пары";
            this.showCouples.UseVisualStyleBackColor = true;
            this.showCouples.Click += new System.EventHandler(this.showCouples_Click);
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
            // lessQuadsButton
            // 
            this.lessQuadsButton.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lessQuadsButton.Location = new System.Drawing.Point(543, 236);
            this.lessQuadsButton.Name = "lessQuadsButton";
            this.lessQuadsButton.Size = new System.Drawing.Size(142, 70);
            this.lessQuadsButton.TabIndex = 4;
            this.lessQuadsButton.Text = "Метод наименьших квадратов";
            this.lessQuadsButton.UseVisualStyleBackColor = true;
            this.lessQuadsButton.Click += new System.EventHandler(this.lessQuadsButton_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 523);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shouDotsButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.lessQuadsButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showCouples);
            this.Controls.Add(this.importButton);
            this.Name = "Form1";
            this.Text = "Приближение функций";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button showCouples;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button lessQuadsButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button shouDotsButton;
        private System.Windows.Forms.Label label1;
    }
}

