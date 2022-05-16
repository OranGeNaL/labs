using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace optimization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //minMaxComboBox.Text = "MAX";
            nCounter.Value = 6;
            mCounter.Value = 3;
            FillMatrix(
                new string[,] {
                    {"13", "1", "2", "3", "1", "0", "0" },
                    {"9", "2", "1", "4", "0", "1", "0" },
                    {"32", "4", "3", "1", "0", "0", "1" },
                },
                new string[] { "1", "2", "3", "0", "0", "0" }
            );
            matrixTable.Font = new Font("Cascadia Mono", 10f, FontStyle.Regular);
            coefsTable.Font = new Font("Cascadia Mono", 10f, FontStyle.Regular);
        }

        double M = 123456;

        private void FillMatrix(string[,] matrix, string[] coefs)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i) {
                for (int j = 0; j < matrix.GetLength(1); ++j) {
                    matrixTable.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
            for (int i = 0; i < coefs.GetLength(0); ++i) {
                coefsTable.Rows[0].Cells[i].Value = coefs[i];
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            int n = (int)nCounter.Value;
            int m = (int)mCounter.Value;
            var rows = matrixTable.Rows.Cast<DataGridViewRow>();
            var matrix = new double[m, n + 1];
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n + 1; ++j) {
                    matrix[i, j] = double.Parse(matrixTable.Rows[i].Cells[j].FormattedValue.ToString());
                }
            }

            var basisVector = Enumerable.Repeat(-1, m).ToList();
            for (int i = 0; i < m; ++i) {
                for (int j = 1; j <= n; ++j) {
                    if (matrix[i, j] == 1 && rows.All(row => row.Index == i || row.Cells[j].Value.ToString() == "0")) {
                        basisVector[i] = j - 1;
                        break;
                    }
                }
            }

            var newIndices = Enumerable.Range(0, m).Where(i => basisVector[i] == -1).ToList();
            var newMatrix = new double[m, n + 1 + newIndices.Count];
            for (int i = 0; i < m; ++i) {
                for (int j = 0; j < n + 1; ++j) {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < newIndices.Count; ++i) {
                newMatrix[newIndices[i], n + 1 + i] = 1;
                basisVector[newIndices[i]] = n + i;
            }
            n = n + newIndices.Count;
            matrix = newMatrix;

            bool min = false;//minMaxComboBox.Text == "MIN";
            var coefs = coefsTable.Rows[0].Cells.Cast<DataGridViewCell>().
                Select(i => double.Parse(i.FormattedValue.ToString())).ToList();
            if (coefs.Count < n) {
                coefs.AddRange(Enumerable.Repeat(-M, n - coefs.Count));
            }
            if (min) {
                coefs = coefs.Select(i => i * -1).ToList();
            }

            outputTable.Rows.Clear();
            outputTable.Columns.Clear();
            outputTable.Refresh();
            outputTable.DefaultCellStyle.Font = new Font("Cascadia Mono", 10f, FontStyle.Bold);
            outputTable.ColumnCount = n + 4;
            outputTable.Columns[0].HeaderText = "C";
            outputTable.Columns[0].DefaultCellStyle.BackColor = Color.Silver;
            outputTable.Columns[1].HeaderText = "Б";
            outputTable.Columns[1].DefaultCellStyle.BackColor = Color.LightGreen;
            outputTable.Columns[n + 2].HeaderText = "a";
            outputTable.Columns[n + 2].DefaultCellStyle.BackColor = Color.Gold;
            outputTable.Columns[n + 3].HeaderText = "θ";
            outputTable.Columns[n + 3].DefaultCellStyle.BackColor = Color.Wheat;
            for (int j = 0; j < n - newIndices.Count; ++j) {
                outputTable.Columns[j + 2].HeaderText = $"X{j + 1}";
            }
            for (int j = n - newIndices.Count; j < n; ++j) {
                outputTable.Columns[j + 2].HeaderText = $"Y{j - (n - newIndices.Count) + 1}";
            }
            int it = 0;
            while (true) {
                var c = basisVector.Select(i => coefs[i]).ToArray();
                var zA = new double[n + 1];
                var zB = new double[n + 1];
                for (int i = 0; i < n + 1; ++i) {
                    for (int j = 0; j < m; ++j) {
                        if (Math.Abs(c[j]) == M) {
                            zA[i] += Math.Sign(c[j]) * matrix[j, i];
                        } else {
                            zB[i] += c[j] * matrix[j, i];
                        }
                    }
                    if (i != 0) {
                        if (Math.Abs(coefs[i - 1]) == M) {
                            zA[i] -= Math.Sign(coefs[i - 1]);
                        } else {
                            zB[i] -= coefs[i - 1];
                        }
                    }
                }
                
                for (int i = 1; i < n; ++i) {
                    if (zA[i] * M + zB[i] < 0) {
                        int negCount = 0;
                        for (int j = 0; j < m; ++j) {
                            if (matrix[j, i] <= 0) {
                                negCount++;
                            }
                        }
                        if (negCount == m) {
                            FillOutput(c, basisVector, zA, zB, new double[m], matrix, m, n, it * (m + 2));
                            mResultTextBox.Text = "Нет решений, т.к. целевая функция не ограничена";
                            resultTextBox.Text = "Нет решений";
                            zLabel.Text = "";
                            label7.Visible = false;
                            return;
                        }
                    }
                }
                
                int selectedCol = 1;
                for (int i = 1; i < n + 1; ++i) {
                    var zI = zA[i] * M + zB[i];
                    var zSelected = zA[selectedCol] * M + zB[selectedCol];
                    if (zI < zSelected) {
                        selectedCol = i;
                    }
                }
                if (Math.Round(zA[selectedCol] * M + zB[selectedCol], 6) >= 0) {
                    FillOutput(c, basisVector, zA, zB, new double[m], matrix, m, n, it * (m + 2));
                    break;
                }

                var simplex = new double[m];
                for (int i = 0; i < m; ++i) {
                    simplex[i] = (matrix[i, selectedCol] > 0) ? matrix[i, 0] / matrix[i, selectedCol] :
                        double.MaxValue;
                }
                
                int selectedRow = simplex.Length - 1;
                for (int i = simplex.Length - 1; i >= 0; --i) {
                    if (simplex[i] < simplex[selectedRow]) {
                        selectedRow = i;
                    }
                }
                FillOutput(c, basisVector, zA, zB, simplex, matrix, m, n, it * (m + 2), selectedRow, selectedCol);
                newMatrix = (double[,])matrix.Clone();
                for (int i = 0; i < n + 1; ++i) {
                    newMatrix[selectedRow, i] /= matrix[selectedRow, selectedCol];
                }
                basisVector[selectedRow] = selectedCol - 1;
                c[selectedRow] = coefs[selectedCol - 1];
                for (int i = 0; i < m; ++i) {
                    if (i == selectedRow) continue;
                    for (int j = 0; j < n + 1; ++j) {
                        newMatrix[i, j] = matrix[selectedRow, selectedCol] * matrix[i, j] -
                            matrix[selectedRow, j] * matrix[i, selectedCol];
                        newMatrix[i, j] /= matrix[selectedRow, selectedCol];
                    }
                }
                matrix = newMatrix;
                it++;
            }
            var mResult = new double[coefs.Count];
            double zMax = 0;
            for (int i = 0; i < basisVector.Count; ++i) {
                mResult[basisVector[i]] = matrix[i, 0];
                zMax += mResult[basisVector[i]] * coefs[basisVector[i]];
            }
            mResultTextBox.Text = "(" + string.Join(", ", mResult) + ")";
            var result = new double[coefs.Count - newIndices.Count];
            for (int i = 0; i < result.Length; ++i) {
                result[i] = mResult[i];
            }
            for (int i = mResult.Length - newIndices.Count; i < mResult.Length; ++i) {
                if (mResult[i] != 0) {
                    resultTextBox.Text = "Нет решений";
                    zLabel.Text = "";
                    label7.Visible = false;
                    return;
                }
            }
            resultTextBox.Text = "(" + string.Join(", ", result) + ")";
            zLabel.Text = zMax.ToString();
            label7.Visible = true;
        }

        private void FillOutput(double[] c, List<int> basis, double[] zA, double[] zB, double[] simplex, double[,] matrix, int m, int n, int fromRow, int selectedRow = -1, int selectedCol = -1)
        {
            outputTable.RowCount = fromRow + m + 2;
            for (int i = 0; i < m; ++i) {
                if (Math.Abs(c[i]) == M) {
                    outputTable.Rows[i + fromRow].Cells[0].Value = Math.Sign(c[i]) == -1 ? "-M" : "M";
                } else {
                    outputTable.Rows[i + fromRow].Cells[0].Value = c[i];
                }
                //outputTable.Rows[i + fromRow].Cells[1].Value = $"X{basis[i] + 1}";
                outputTable.Rows[i + fromRow].Cells[1].Value = (basis[i] < nCounter.Value ? $"X{basis[i] + 1}" : $"Y{basis[i] - nCounter.Value + 1}");


                outputTable.Rows[i + fromRow].Cells[n + 2].Value = Math.Round(matrix[i, 0], 6);
                outputTable.Rows[i + fromRow].Cells[n + 3].Value = simplex[i] == double.MaxValue ? "-" : Math.Round(simplex[i], 6).ToString();
                for (int j = 0; j < n; ++j) {
                    outputTable.Rows[i + fromRow].Cells[j + 2].Value = Math.Round(matrix[i, j + 1], 6);
                }
            }
            outputTable.Rows[outputTable.RowCount - 2].Cells[1].Value = "b";
            outputTable.Rows[outputTable.RowCount - 2].Cells[n + 2].Value = Math.Round(zB[0], 6);
            outputTable.Rows[outputTable.RowCount - 2].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            outputTable.Rows[outputTable.RowCount - 1].Cells[0].Value = "M * ";
            outputTable.Rows[outputTable.RowCount - 1].Cells[1].Value = "a";
            outputTable.Rows[outputTable.RowCount - 1].Cells[n + 2].Value = Math.Round(zA[0], 6);
            outputTable.Rows[outputTable.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            for (int j = 0; j < n; ++j) {
                outputTable.Rows[outputTable.RowCount - 2].Cells[j + 2].Value = Math.Round(zB[j + 1], 6);
                outputTable.Rows[outputTable.RowCount - 1].Cells[j + 2].Value = Math.Round(zA[j + 1], 6);
            }
            if (selectedRow != -1 && selectedCol != -1) {
                outputTable.Rows[selectedRow + fromRow].Cells[selectedCol + 1].Style.BackColor = Color.Red;
            }
        }

        private void NCounter_ValueChanged(object sender, EventArgs e)
        {
            int n = (int)nCounter.Value;
            matrixTable.ColumnCount = 1 + n;
            coefsTable.ColumnCount = n;
            matrixTable.Columns[0].HeaderText = $"a";
            for (int i = 0; i < n; ++i) {
                matrixTable.Columns[i + 1].HeaderText = $"X{i + 1}";
                coefsTable.Columns[i].HeaderText = $"X{i + 1}";
            }
        }

        private void MCounter_ValueChanged(object sender, EventArgs e)
        {
            matrixTable.RowCount = (int)mCounter.Value;
            coefsTable.RowCount = 1;
        }

        private void ReadFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    var text = File.ReadAllLines(dialog.FileName);
                    var coefs = text[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int n = coefs.Length;
                    int m = text.Length - 1;
                    nCounter.Value = n;
                    mCounter.Value = m;
                    var matrix = new string[m, n + 1];
                    for (int i = 0; i < m; ++i) {
                        var row = text[1 + i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < n + 1; ++j) {
                            matrix[i, j] = row[j];
                        }
                    }
                    FillMatrix(matrix, coefs);
                } catch (Exception ex) {
                    MessageBox.Show($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

        private void matrixTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void minMaxComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void resultTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
