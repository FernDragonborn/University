using System.Globalization;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int c;
            float d;
            try
            {
                c = int.Parse(textBox1.Text);
                d = float.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                resultLabel.Text = "Помилка";
                return;
            }
            resultLabel.Text = (c + 4 * d).ToString(CultureInfo.InvariantCulture);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(58, 58, 58);
        }
    }
}