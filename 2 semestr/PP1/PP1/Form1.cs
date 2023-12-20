namespace PP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonCountN.Select();
            this.Text = "������������ 1 �����'�� 612�";
        }

        #region mistakenly generated
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private enum State
        {
            Count,
            Accuracy
        }
        State state = State.Count;

        private void buttonCountN_CheckedChanged(object sender, EventArgs e)
        {
            state = State.Count;
            labelNAndE.Text = "N =";
        }

        private void buttonAccuracyE_CheckedChanged(object sender, EventArgs e)
        {
            state = State.Accuracy;
            labelNAndE.Text = "E =";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float x;
            int n;
            double result;

            if (textBoxX.Text.Length == 0) textBoxX.Text = "0";

            try
            {
                x = float.Parse(textBoxX.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "����������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (x <= 0 || x >= 1)
            {
                MessageBox.Show("�������� � ������� ���� �� 0 �� 1", "�������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (state == State.Count)
            {
                if (textBoxNAndE.Text.Length == 0) textBoxNAndE.Text = "0";
                try
                {
                    n = int.Parse(textBoxNAndE.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (n < 0)
                {
                    MessageBox.Show("ʳ��곳��� �������� �� ���� ���� ��'�����", "�������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                result = x;
                for (int i = 2; i <= n; i++)
                {
                    result += result * (x / i);
                }

                labelResult.Text = result.ToString();
            }

            if (state == State.Accuracy)
            {
                if (textBoxNAndE.Text.Length == 0) textBoxNAndE.Text = "0";
                float epsilon;
                try
                {
                    epsilon = float.Parse(textBoxNAndE.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (epsilon <= 0 || epsilon >= 1)
                {
                    MessageBox.Show("�������� e ������� ���� �� 0 �� 1", "�������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                result = 1;
                float prevResult = (float)result;
                int j = 1;
                while (epsilon >= Math.Abs(result - prevResult) && j < 10000)
                {
                    prevResult = (float)result;
                    result += result * (x / j);
                    j++;
                }

                labelResult.Text = result.ToString();
                labelIterations.Text = j.ToString();
            }

            labelControl.Text = (Math.Exp(x) - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}