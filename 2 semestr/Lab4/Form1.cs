using System.Text.RegularExpressions;

namespace Lab_4
{
    public partial class Lab_4 : Form
    {
        public Lab_4()
        {
            InitializeComponent();
        }

        private int[][] matrix = { };
        static void ClearData(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();
        }

        static void DeleteZeros(ref int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == 0)
                    {
                        DeleteVectorElement(ref arr[i], j);
                        j--;
                    }
                }
            }
        }

        static void DeleteVectorElement(ref int[] arr, int position)
        {
            for (int i = position; i < arr.Length - 1; i++) arr[i] = arr[i + 1];
            Array.Resize(ref arr, arr.Length - 1);
        }

        static void WriteMatrix(int[][] Mas, int size, DataGridView dataGrid)
        {
            dataGrid.ColumnCount = size;
            dataGrid.RowCount = size;

            for (int i = 0; i < Mas.Length; i++)
            {
                dataGrid.Columns[i].HeaderCell.Value = (i + 1).ToString();

                for (int j = 0; j < Mas[i].Length; j++)
                {
                    dataGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    dataGrid.Rows[i].Cells[j].Value = Mas[i][j];
                }
            }

            dataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        static void FillMatrix(out int[][] arr, int size)
        {
            arr = new int[size][];
            for (int i = 0; i < size; i++)
            {
                arr[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    if (j == i || j == size - i - 1)
                    {
                        arr[i][j] = j + 1;
                    }
                }
            }
        }

        private void buttonCreateMatrix_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMatrixRank.Text == "") textBoxMatrixRank.Text = "4";
                if (!Regex.IsMatch(textBoxMatrixRank.Text, @"\b([2-9]|1[0-5])\b")) //розмір від 2 до 15
                {
                    throw new FormatException("Введений рядок некоректний.\nСпробуйте ввести його ще раз");
                }
                // текст введений в текстбокс
                int matrixRank = int.Parse(textBoxMatrixRank.Text);

                //buttonCreateMatrix.Enabled = false;
                FillMatrix(out matrix, matrixRank);
                WriteMatrix(matrix, matrixRank, dataGridCreated);
                buttonDeleteElements.Enabled = true;
            }
            catch (OverflowException ex)
            {
                textBoxMatrixRank.Clear();
                MessageBox.Show($"Введене значення завелике або замале. Спробуйте ще раз\n{ex.Message}\nStack trace:\n{ex.StackTrace}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                textBoxMatrixRank.Clear();
                MessageBox.Show($"Помилка формату данних:\n{ex.Message}\nStack trace:\n{ex.StackTrace}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                textBoxMatrixRank.Clear();
                MessageBox.Show($"\n{ex.Message}\nStack trace:\n{ex.StackTrace}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonDeleteElements.Focus();
        }

        private void DeleteElements_button_Click(object sender, EventArgs e)
        {
            buttonDeleteElements.Enabled = false;
            int matrixRank = int.Parse(textBoxMatrixRank.Text);
            DeleteZeros(ref matrix);
            WriteMatrix(matrix, matrixRank, dataGridDeleted);
            textBoxMatrixRank.Focus();
        }

        private void textBoxMatrixRank_TextChanged(object sender, EventArgs e)
        {
            buttonCreateMatrix.Enabled = true;
            ClearData(dataGridCreated);
            ClearData(dataGridDeleted);
        }
    }
}