namespace Lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        MyStack StackOfData;

        private void додатиЕлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataT.Text=="")
            {
                MessageBox.Show("Немає данних");
                return;
            }
            StackOfData.Push(int.Parse(DataT.Text));
            MessageBox.Show("Додано дані");
            DataT.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((char.IsNumber(e.KeyChar)||(e.KeyChar=='-'))))
            {
                MessageBox.Show("Тільки цифри");
                e.Handled = true;
            }
        }

        private void видалитиОстаннійЕлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StackOfData.Pop();
        }

        private void виведенняРезультатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StackOfData.ToString());
        }

        private void інформаціяПроСтекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StackOfData.Empty())
            {
                MessageBox.Show("Стек пустий");
                return;
            }
            MessageBox.Show("Стек не пустий");
        }

        private void виведенняСтекуНаЕкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StackOfData.StackContaintment();
        }

        private void виведенняРезультатуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(StackOfData.ToString());
        }

        private void вихідToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void інформаціяПроВаріантToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Варіант 18. Лінійний однонаправлений список цілих чисел.\r" +
                "\nВставку і видалення елементів робити за принципом стека.\r\nРеалізувати" +
                "процедуру знаходження максимального елементу.");
        }

        private void stackb_Click(object sender, EventArgs e)
        {
            stackb.Visible = false;
            StackOfData = new MyStack();
            MessageBox.Show("Створено стек");
            menuStrip1.Visible = true;
            menuStrip3.Visible = true;
            DataL.Visible = true;
            DataT.Visible = true;
        }

        private void ShowElToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StackOfData.Peek();
        }
    }
}