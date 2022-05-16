namespace optimization
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.mResultTextBox = new System.Windows.Forms.TextBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.minMaxComboBox = new System.Windows.Forms.ComboBox();
            this.matrixTable = new System.Windows.Forms.DataGridView();
            this.nCounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mCounter = new System.Windows.Forms.NumericUpDown();
            this.readFileButton = new System.Windows.Forms.Button();
            this.coefsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outputTable = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.zLabel = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matrixTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label4.Location = new System.Drawing.Point(12, 557);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Оптимальный план М-задачи:";
            // 
            // mResultTextBox
            // 
            this.mResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mResultTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.mResultTextBox.Location = new System.Drawing.Point(12, 577);
            this.mResultTextBox.Name = "mResultTextBox";
            this.mResultTextBox.Size = new System.Drawing.Size(893, 23);
            this.mResultTextBox.TabIndex = 7;
            // 
            // solveButton
            // 
            this.solveButton.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.solveButton.Location = new System.Drawing.Point(12, 98);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(232, 47);
            this.solveButton.TabIndex = 8;
            this.solveButton.Text = "Посчитать";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // minMaxComboBox
            // 
            this.minMaxComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minMaxComboBox.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.minMaxComboBox.FormattingEnabled = true;
            this.minMaxComboBox.Items.AddRange(new object[] {
            "MIN",
            "MAX"});
            this.minMaxComboBox.Location = new System.Drawing.Point(863, 121);
            this.minMaxComboBox.Name = "minMaxComboBox";
            this.minMaxComboBox.Size = new System.Drawing.Size(195, 25);
            this.minMaxComboBox.TabIndex = 11;
            this.minMaxComboBox.Visible = false;
            this.minMaxComboBox.SelectedIndexChanged += new System.EventHandler(this.minMaxComboBox_SelectedIndexChanged);
            // 
            // matrixTable
            // 
            this.matrixTable.AllowUserToAddRows = false;
            this.matrixTable.AllowUserToDeleteRows = false;
            this.matrixTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matrixTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.matrixTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.matrixTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.matrixTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.matrixTable.Location = new System.Drawing.Point(261, 29);
            this.matrixTable.MultiSelect = false;
            this.matrixTable.Name = "matrixTable";
            this.matrixTable.RowHeadersVisible = false;
            this.matrixTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.matrixTable.Size = new System.Drawing.Size(644, 116);
            this.matrixTable.TabIndex = 13;
            this.matrixTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrixTable_CellContentClick);
            // 
            // nCounter
            // 
            this.nCounter.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.nCounter.Location = new System.Drawing.Point(207, 35);
            this.nCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCounter.Name = "nCounter";
            this.nCounter.Size = new System.Drawing.Size(37, 23);
            this.nCounter.TabIndex = 14;
            this.nCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nCounter.ValueChanged += new System.EventHandler(this.NCounter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Количество переменных:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label6.Location = new System.Drawing.Point(9, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Количество ограничений:";
            // 
            // mCounter
            // 
            this.mCounter.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.mCounter.Location = new System.Drawing.Point(207, 67);
            this.mCounter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mCounter.Name = "mCounter";
            this.mCounter.Size = new System.Drawing.Size(37, 23);
            this.mCounter.TabIndex = 16;
            this.mCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mCounter.ValueChanged += new System.EventHandler(this.MCounter_ValueChanged);
            // 
            // readFileButton
            // 
            this.readFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readFileButton.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.readFileButton.Location = new System.Drawing.Point(862, 29);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(196, 28);
            this.readFileButton.TabIndex = 18;
            this.readFileButton.Text = "Из файла";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Visible = false;
            this.readFileButton.Click += new System.EventHandler(this.ReadFileButton_Click);
            // 
            // coefsTable
            // 
            this.coefsTable.AllowUserToAddRows = false;
            this.coefsTable.AllowUserToDeleteRows = false;
            this.coefsTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coefsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.coefsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.coefsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.coefsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.coefsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.coefsTable.Location = new System.Drawing.Point(12, 168);
            this.coefsTable.MultiSelect = false;
            this.coefsTable.Name = "coefsTable";
            this.coefsTable.RowHeadersVisible = false;
            this.coefsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.coefsTable.Size = new System.Drawing.Size(893, 60);
            this.coefsTable.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Симплекс таблица:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ограничения исходной задачи:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Коэффициенты целевой функции:";
            // 
            // outputTable
            // 
            this.outputTable.AllowUserToAddRows = false;
            this.outputTable.AllowUserToDeleteRows = false;
            this.outputTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.outputTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.outputTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.outputTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.outputTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.outputTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.outputTable.Location = new System.Drawing.Point(12, 251);
            this.outputTable.MultiSelect = false;
            this.outputTable.Name = "outputTable";
            this.outputTable.RowHeadersVisible = false;
            this.outputTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.outputTable.Size = new System.Drawing.Size(893, 303);
            this.outputTable.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label7.Location = new System.Drawing.Point(12, 649);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(320, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Значение функции при оптимальном плане:";
            // 
            // zLabel
            // 
            this.zLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zLabel.AutoSize = true;
            this.zLabel.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.zLabel.Location = new System.Drawing.Point(339, 649);
            this.zLabel.Name = "zLabel";
            this.zLabel.Size = new System.Drawing.Size(0, 17);
            this.zLabel.TabIndex = 22;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.resultTextBox.Location = new System.Drawing.Point(12, 623);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(893, 23);
            this.resultTextBox.TabIndex = 24;
            this.resultTextBox.TextChanged += new System.EventHandler(this.resultTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Mono", 9.75F);
            this.label8.Location = new System.Drawing.Point(12, 603);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Оптимальный план исходной задачи:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 692);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.zLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.outputTable);
            this.Controls.Add(this.coefsTable);
            this.Controls.Add(this.readFileButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nCounter);
            this.Controls.Add(this.matrixTable);
            this.Controls.Add(this.minMaxComboBox);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.mResultTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.matrixTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mResultTextBox;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.ComboBox minMaxComboBox;
        private System.Windows.Forms.DataGridView matrixTable;
        private System.Windows.Forms.NumericUpDown nCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown mCounter;
        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.DataGridView coefsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView outputTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label zLabel;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label8;
    }
}

