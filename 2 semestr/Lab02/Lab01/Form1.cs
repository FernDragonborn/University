namespace Lab01
{
    public partial class Form1 : Form
    {
        private bool isCatchingExceptions = false;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Select();
            aTextBox.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isCatchingExceptions)
            {
                try
                {
                    CalculateResult();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Помилка діапазону", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else
            {
                CalculateResult();
            }

        }

        private void CalculateResult()
        {
            float a = float.Parse(aTextBox.Text);
            float b = float.Parse(bTextBox.Text);
            float c = float.Parse(cTextBox.Text);
            float d = float.Parse(dTextBox.Text);
            resultLabel.Text = ((c / b - Math.Sqrt(24 + d) + a) / (2 * a * c - 1)).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(58, 58, 58);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isCatchingExceptions = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isCatchingExceptions = false;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}