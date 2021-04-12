
namespace Task1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.tbA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbF = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ch = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lb = new System.Windows.Forms.ListBox();
            this.btWork = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A =";
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(54, 35);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(36, 20);
            this.tbA.TabIndex = 1;
            this.tbA.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "B =";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(137, 35);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(36, 20);
            this.tbB.TabIndex = 1;
            this.tbB.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "C =";
            // 
            // tbC
            // 
            this.tbC.Location = new System.Drawing.Point(225, 35);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(36, 20);
            this.tbC.TabIndex = 1;
            this.tbC.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(498, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "D =";
            // 
            // tbD
            // 
            this.tbD.Location = new System.Drawing.Point(527, 35);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(36, 20);
            this.tbD.TabIndex = 1;
            this.tbD.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(587, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "E =";
            // 
            // tbE
            // 
            this.tbE.Location = new System.Drawing.Point(616, 35);
            this.tbE.Name = "tbE";
            this.tbE.Size = new System.Drawing.Size(36, 20);
            this.tbE.TabIndex = 1;
            this.tbE.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(686, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "F =";
            // 
            // tbF
            // 
            this.tbF.Location = new System.Drawing.Point(715, 35);
            this.tbF.Name = "tbF";
            this.tbF.Size = new System.Drawing.Size(36, 20);
            this.tbF.TabIndex = 1;
            this.tbF.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbA);
            this.groupBox1.Controls.Add(this.tbE);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbB);
            this.groupBox1.Controls.Add(this.tbD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbC);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 99);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Входные данные";
            // 
            // ch
            // 
            chartArea2.Name = "ChartArea1";
            this.ch.ChartAreas.Add(chartArea2);
            this.ch.Location = new System.Drawing.Point(12, 117);
            this.ch.Name = "ch";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Name = "Series2";
            this.ch.Series.Add(series3);
            this.ch.Series.Add(series4);
            this.ch.Size = new System.Drawing.Size(610, 329);
            this.ch.TabIndex = 3;
            this.ch.Text = "chart1";
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.Location = new System.Drawing.Point(628, 130);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(160, 316);
            this.lb.TabIndex = 4;
            // 
            // btWork
            // 
            this.btWork.Location = new System.Drawing.Point(689, 101);
            this.btWork.Name = "btWork";
            this.btWork.Size = new System.Drawing.Size(93, 23);
            this.btWork.TabIndex = 5;
            this.btWork.Text = "Обработать";
            this.btWork.UseVisualStyleBackColor = true;
            this.btWork.Click += new System.EventHandler(this.btWork_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.btWork);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.ch);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Задание 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch;
        private System.Windows.Forms.ListBox lb;
        private System.Windows.Forms.Button btWork;
    }
}

