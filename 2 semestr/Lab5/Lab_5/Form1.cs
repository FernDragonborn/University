using System.Text;
using System.Text.RegularExpressions;

namespace Lab_5
{
    public partial class Lab_5 : Form
    {
        public Lab_5()
        {
            InitializeComponent();
        }
        private const char WordEnd = ' ', SentenseEnd = '.';
        private const int MinWordLenght = 1, MaxWordLenght = 5;
        private const string NoDuplicates = "���� ��������";

        private static void CheckForRepeatsInSentence(ref string input)
        {
            var sentense = input.Split(WordEnd, StringSplitOptions.RemoveEmptyEntries);
            var duplicates = new List<string>();
            foreach (var word in sentense)
            {
                foreach (var letter in word)
                {
                    if (word.IndexOf(letter) != word.LastIndexOf(letter))
                    {
                        duplicates.Add(word);
                        break;
                    }
                }
            }

            var sb = new StringBuilder();
            if (duplicates.Count == 0) sb.Append(NoDuplicates);
            else
            {
                for (int i = 0; i < duplicates.Count; i++)
                {
                    string? word = duplicates[i];
                    sb.Append(word);
                    sb.Append('\n');
                }
            }
            input = sb.ToString();
            duplicates.Clear();
        }

        private void ExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ResultRichTextBox.Clear();
                var phrase = InputTextBox.Text;
                if (phrase == "") throw new FormatException("����� �� ���� ���� ������");
                if (phrase.Trim() == "") throw new FormatException("����� �� ���� ���������� ����� � ������");

                ResultRichTextBox.Text += "���������� �����:\n" + phrase;
                CheckForRepeatsInSentence(ref phrase);
                if (phrase == NoDuplicates) ResultRichTextBox.Text += "\n\n������� ���� � ������ ����";
                else ResultRichTextBox.Text += $"\n\n����� �� ������������� �������:\n{phrase}";
                //Result_richTextBox.Enabled = false;
                ResultRichTextBox.Visible = true;
                ResultRichTextBox.Focus();
            }
            catch (FormatException ex) { MessageBox.Show(ex.Message, "�����������", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TextBoxInputPhrase_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sentence = ((TextBox)sender).Text;
            try
            {
                if (DoShowDebugMessageToolStripMenuItem.Checked == true)
                {
                    MessageBox.Show("� ���������:" + sentence);
                    MessageBox.Show("��������� ������ " + e.KeyChar);
                }

                if (e.KeyChar == SentenseEnd)
                {
                    if (sentence.Length - sentence.LastIndexOf(WordEnd) <= MinWordLenght)
                    {
                        e.KeyChar = '\0';
                        return; //throw new Exception("����� �� ���� ����� 10 �������");
                    }

                    sentence += e.KeyChar;
                    e.KeyChar = SentenseEnd;
                    InputTextBox.Text = sentence; // ��������� ����� � ���� �����
                    InputTextBox.ReadOnly = true;
                    ResultRichTextBox.Focus();
                }
                else if (e.KeyChar == WordEnd)
                {
                    if (sentence.Length - sentence.LastIndexOf(WordEnd) <= MinWordLenght)
                    {
                        e.KeyChar = '\0';
                        throw new FormatException("����� �� ���� ����� 2 �������");
                    }
                }
                else if
                    (!Regex.IsMatch(e.KeyChar.ToString(),
                        "^[A-Z .\b\r]+$")) //����� ����� ����� �������� �����, ������ �� ������
                {
                    //if (Regex.IsMatch(e.KeyChar.ToString(), "^[\b\r]+$")) break;
                    e.KeyChar = '\0';
                    throw new FormatException("������������ ����� ����� �������� �����, ������ �� ������ � ����");
                }

                else if (sentence.Length - sentence.LastIndexOf(WordEnd) > MaxWordLenght)
                {
                    if (e.KeyChar == '\b' || e.KeyChar == '\r') return;
                    e.KeyChar = '\0';
                    throw new FormatException("����������� ������� ����� - 5 �������");
                }
            }
            catch (FormatException ex) { MessageBox.Show(ex.Message, "�����������", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void MinimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void InputTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox.Focus();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearInputTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox.ReadOnly = false;
            InputTextBox.Clear();
        }

        private void ClearResultTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox.ReadOnly = false;
            ResultRichTextBox.Clear();
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox.ReadOnly = false;
            InputTextBox.Clear();
            ResultRichTextBox.Clear();
        }

        private void DoShowDebugMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoShowDebugMessageToolStripMenuItem.Checked = DoShowDebugMessageToolStripMenuItem.Checked == false;
        }

        private void TextBoxInputPhrase_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void TextBoxInputPhrase_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ExecuteToolStripMenuItem_Click(sender, e);
        }
    }
}