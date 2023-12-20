namespace Lab_7
{
    public partial class Lab_7 : Form
    {
        public Lab_7()
        {
            InitializeComponent();
        }

        bool saved = false;
        bool opened = false;
        string filePath = "";

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ResetWindow();
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                opened = true;
                saved = true;
                filePath = openFileDialog.FileName;
                var fileInfo = new FileInfo(filePath);
                if (fileInfo.Length == 0) throw new Exception("Файл пустий!\nОберіть інший");

                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var binReader = new BinaryReader(stream);

                string fileContent = "";
                stream.Seek(0, SeekOrigin.Begin);
                while (stream.Position < stream.Length) fileContent += Convert.ToString(binReader.ReadSingle()) + ';';

                InputLabel.Text = "Вміст відкритого двійкового (bin) файлу:";
                InputLabel.Visible = true;
                InputTextBox.Text = fileContent;
                InputTextBox.Visible = true;

                binReader.Close();
                stream.Close();
            }
            catch (FileNotFoundException ex) { MessageBox.Show("Файл не знайдено!\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (IOException ex) { MessageBox.Show("При відкритті, читанні або запису файлу виникла помилка\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (UnauthorizedAccessException ex) { MessageBox.Show("У програми немає необхідних дозволів для доступу до файлу.\nНаприклад, файл захищений від запису або доступний тільки для читання\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (FormatException ex) { MessageBox.Show("Рядок введений в некоректному форматі числа.\nПеревірте правильність введення вхідних даних\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (OverflowException ex) { MessageBox.Show($"Введене число перевищує тип даних float\numbersQuantity({float.MinValue} - {float.MaxValue})\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changedFileContent = "";

            if (!saved || !opened)
            {
                DialogResult result = MessageBox.Show("Ви ще не зберегли файл.\nБажаєте зберегти файл для подальшої обробки", "Повідомленя", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) SaveToolStripMenuItem_Click(sender, e);
            }
            try
            {
                ReplacePluralWithNegativeSum(filePath, out float negativeSum, ElementQuantityLabel);

                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var reader = new BinaryReader(stream);

                stream.Seek(0, SeekOrigin.Begin);
                while (stream.Position < stream.Length) changedFileContent += Convert.ToString(reader.ReadSingle()) + ';';

                NegativeSumLabel.Text = "Сума, на яку будуть замінені непарні числа: " + Convert.ToString(Math.Abs(negativeSum));
                NegativeSumLabel.Visible = true;
                ChangedLabel.Visible = true;
                ChangedTextBox.Visible = true;
                ChangedTextBox.Text = changedFileContent;
                reader.Close();
                stream.Close();
            }
            catch (FileNotFoundException ex) { MessageBox.Show("Файл не знайдено!\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (IOException ex) { MessageBox.Show($"{ex.Message}\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (UnauthorizedAccessException ex) { MessageBox.Show("У програми немає необхідних дозволів для доступу до файлу.\nНаприклад, файл захищений від запису або доступний тільки для читання\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (FormatException ex) { MessageBox.Show("Рядок введений в некоректному форматі числа.\nПеревірте правильність введення вхідних даних\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (OverflowException ex) { MessageBox.Show($"Введене число перевищує тип даних float\numbersQuantity({float.MinValue} - {float.MaxValue})\n\nStackTrace:\n" + ex.StackTrace, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private static void ReplacePluralWithNegativeSum(string filePath, out float negativeSum, Label label)
        {
            negativeSum = 0;
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            var binReader = new BinaryReader(stream);
            var binWriter = new BinaryWriter(stream);

            var numbersQuantity = stream.Length / 4;
            label.Text = "Загальна кількість елементів файлу: " + numbersQuantity;
            label.Visible = true;
            try
            {
                while (true)
                {
                    float element = binReader.ReadSingle();
                    if (element == float.NegativeInfinity || element == float.PositiveInfinity) throw new OverflowException();
                    if (element < 0) negativeSum += element;
                }
            }
            catch (EndOfStreamException) { }
            try
            {
                binReader.BaseStream.Seek(0, SeekOrigin.Begin);
                while (true)
                {
                    float element = binReader.ReadSingle();
                    if (element > 0)
                    {
                        binWriter.Seek(-4, SeekOrigin.Current);
                        element = negativeSum;
                        binWriter.Write(element);
                    }
                }
            }
            catch (EndOfStreamException) { }
            binReader.Close();
            binWriter.Close();
            stream.Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            var stream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            var binWriter = new BinaryWriter(stream);
            try
            {
                filePath = saveFileDialog.FileName;
                string shortFileName = Path.GetFileName(filePath);

                char[] separators = { '.', ' ', ';' };
                foreach (string element in InputTextBox.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
                {
                    float num = float.Parse(element.TrimStart());
                    binWriter.Write(num);
                }

                MessageBox.Show("Файл " + shortFileName + " успішно збережено по шляху:\numbersQuantity" + filePath, "Повідомлення", MessageBoxButtons.OK, MessageBoxIcon.Information);

                saved = true;
            }
            catch (FileNotFoundException) { MessageBox.Show("Файл не знайдено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (IOException) { MessageBox.Show("При відкритті, читанні або запису файлу виникла помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (UnauthorizedAccessException) { MessageBox.Show("У програми немає необхідних дозволів для доступу до файлу.\nНаприклад, файл захищений від запису або доступний тільки для читання", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (FormatException) { MessageBox.Show("Рядок введений в некоректному форматі числа.\nПеревірте правильність введення вхідних даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (OverflowException) { MessageBox.Show("Введене число перевищує тип даних float " + "\numbersQuantity(" + int.MinValue + " - " + int.MaxValue + ')', "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                binWriter.Close();
                stream.Close();
            }
        }

        private void CreateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetWindow();
            string generated = GenerateStringFloats();
            InputTextBox.Text = generated;
            InputTextBox.ReadOnly = true;
            InputLabel.Text = "Згенеровані дані:";
            InputLabel.Visible = true;
            InputTextBox.Visible = true;
        }

        private static string GenerateStringFloats()
        {
            string result = "";
            var random = new Random();
            var elementQuantity = random.Next(1, 16);
            for (int i = 0; i < elementQuantity; i++)
            {
                double mantissa = (random.NextDouble() * 2.0) - 1.0;
                // choose -149 instead of -126 to also generate subnormal floats (*)
                double exponent = Math.Pow(2.0, random.Next(-126, 128));
                float num = float.Parse($"{mantissa * exponent}");
                result += (num + ";");
            }
            return result.TrimEnd();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KeyboardEnterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetWindow();
            InputTextBox.Clear();
            InputLabel.Text = "Введіть данні для обробки через крапку з комою";
            InputLabel.Visible = true;
            InputTextBox.Visible = true;
            InputTextBox.ReadOnly = false;
            InputTextBox.Focus();
        }

        private void ResetWindow()
        {
            InputTextBox.Clear();
            ChangedLabel.Visible = false;
            ChangedTextBox.Visible = false;
            ElementQuantityLabel.Visible = false;
            NegativeSumLabel.Visible = false;
        }
    }
}