﻿namespace Lab4
{
    partial class Form2
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
            this.cancelButtot = new System.Windows.Forms.Button();
            this.importAccept = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButtot
            // 
            this.cancelButtot.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButtot.Location = new System.Drawing.Point(240, 60);
            this.cancelButtot.Name = "cancelButtot";
            this.cancelButtot.Size = new System.Drawing.Size(69, 23);
            this.cancelButtot.TabIndex = 7;
            this.cancelButtot.Text = "Отмена";
            this.cancelButtot.UseVisualStyleBackColor = true;
            this.cancelButtot.Click += new System.EventHandler(this.cancelButtot_Click);
            // 
            // importAccept
            // 
            this.importAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.importAccept.Location = new System.Drawing.Point(328, 60);
            this.importAccept.Name = "importAccept";
            this.importAccept.Size = new System.Drawing.Size(107, 23);
            this.importAccept.TabIndex = 6;
            this.importAccept.Text = "Импортировать";
            this.importAccept.UseVisualStyleBackColor = true;
            this.importAccept.Click += new System.EventHandler(this.importAccept_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(423, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "C:\\Users\\pshen\\Documents\\GitHub\\labs\\6_semestr\\VisualProg\\labs\\Lab6\\primer1.txt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите путь к файлу, содержащему пары значений";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 98);
            this.Controls.Add(this.cancelButtot);
            this.Controls.Add(this.importAccept);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Импорт";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButtot;
        private System.Windows.Forms.Button importAccept;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}