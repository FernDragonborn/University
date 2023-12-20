using System.Text;
using System.Text.RegularExpressions;

namespace lab6
{
    public partial class Lab6 : Form
    {
        public Lab6()
        {
            InitializeComponent();
            DragEnter += DragNDrop_Animate;
            DragDrop += DragNDrop;
            openFileButton.Select();
        }

        internal const char WordEnd = ' ';
        internal bool IsOpened = false, IsDropped = false;
        internal string Filenameread = "";

        private static void CheckRepeatedSymbolsInWords(ref string input, StreamWriter sw)
        {
            if (input == "") throw new FormatException("Рядок не може бути пустим");
            if (!RegexFiveBigLettersInEachWord().IsMatch(input)) throw new FormatException("Будь ласка, у файлі введіть від 1 до 5 слів влеикими латинськими літерами через пробіл");

            input = input.TrimEnd();
            sw.WriteLine("Зчитано рядок: " + input);
            sw.WriteLine("\nСлова із дубльованими літерами:");
            var sentense = input.Split(WordEnd, StringSplitOptions.RemoveEmptyEntries);
            input = "";
            foreach (var word in sentense)
            {
                foreach (var letter in word)
                {
                    if (word.IndexOf(letter) != word.LastIndexOf(letter))
                    {
                        input += " " + word;
                        break;
                    }
                }
            }
            input = input.TrimEnd(WordEnd);
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog_input.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var shortFileName = Path.GetFileName(openFileDialog_input.FileName);
                var filePath = openFileDialog_input.FileName;
                FileInfo fileInfo = new(filePath);

                if (fileInfo.Length == 0)
                    throw new Exception("Файл пустий!\nОберіть інший");

                PathToFileLabel.Text = "Відкрийтий файл: " + shortFileName;
                PathToFileLabel.Visible = true;
                IsOpened = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var filenameforall = "";
            save_result_FileDialog.Filter = "Text Files (*.txt)|*.txt|Word Documents (*.doc)|*.doc";
            if (save_result_FileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string s;
            if (IsOpened)
            {
                filenameforall = openFileDialog_input.FileName;
            }
            else if (IsDropped)
            {
                filenameforall = Filenameread;
            }

            //else if (IsOpened == false && IsDropped == false)
            //{
            //    throw new Exception("Ви не обрали жоден файл для зчитування");
            //}
            if (filenameforall == "")
            {
                MessageBox.Show($"Перед обробкою оберіть файл!", "Файл на обрано", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            StreamReader sr = new(filenameforall);
            StreamWriter sw = new(save_result_FileDialog.FileName, false, Encoding.Default);

            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    CheckRepeatedSymbolsInWords(ref s, sw);
                    sw.Write(s);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"{ex.Message}\nStack trace:\n{ex.StackTrace}");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файлу з ім'ям" + filenameforall + " не існує!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sr.Close();
                sw.Close();
                MessageBox.Show("Результат успішно збережено у файлі:\n" + save_result_FileDialog.FileName);
                PathToFileLabel.Text = "Результат у файлі:\n" + save_result_FileDialog.FileName;
            }
        }


        private void DragNDrop_Animate(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DragNDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                Filenameread = file;
                var reader = new StreamReader(file);
                //var content = reader.ReadToEnd();
                try
                {
                    var shortFileName = Path.GetFileName(file);
                    var filePath = Path.GetFullPath(file);
                    FileInfo fileInfo = new(filePath);

                    if (fileInfo.Length == 0)
                        throw new Exception("Файл пустий!\nОберіть інший");

                    PathToFileLabel.Text = "Відкрийтий файл: " + shortFileName;
                    PathToFileLabel.Visible = true;
                    IsDropped = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                finally
                {
                    reader.Close();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(sender, e);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(sender, e);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        [GeneratedRegex("^[A-Z]{1,5}( [A-Z]{1,5})*(?:\\.)?$")]
        private static partial Regex RegexFiveBigLettersInEachWord();
    }
}