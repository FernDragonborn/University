using Lab8.Figures;

namespace Lab8
{
    public partial class Lab8 : Form
    {
        private List<IFigure> figureList = new();
        private FigureEnum whichFigure = FigureEnum.rectangle;
        internal enum FigureEnum
        {
            rectangle,
            triangle
        }
        public Lab8()
        {
            InitializeComponent();
            RectangleRadioButton.Select();
            cTextBox.Visible = false;
            cLabel.Visible = false;
        }

        private void RectangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            whichFigure = FigureEnum.rectangle;
            RectangleRadioButton.Checked = true;
            TriangleRadioButton.Checked = false;
            cTextBox.Visible = false;
            cLabel.Visible = false;
        }

        private void TriangleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            whichFigure = FigureEnum.triangle;
            RectangleRadioButton.Checked = false;
            TriangleRadioButton.Checked = true;
            cTextBox.Visible = true;
            cLabel.Visible = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (whichFigure == FigureEnum.rectangle)
                {
                    figureList.Add(
                        new Figures.Rectangle(
                            Convert.ToInt32(aTextBox.Text),
                            Convert.ToInt32(bTextBox.Text)
                        ));
                }
                else if (whichFigure == FigureEnum.triangle)
                {
                    figureList.Add(
                        new Figures.Triangle(
                            Convert.ToInt32(aTextBox.Text),
                            Convert.ToInt32(bTextBox.Text),
                            Convert.ToInt32(cTextBox.Text))
                    );
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"�������, �� �� �������� ����� ������� ��� ������!\n\nException:\n{ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex) { MessageBox.Show($"�������, �� �� �������� ����� ������� ��� ������!\n\nException:\n{ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            ListButton_Click(sender, e);
        }

        private void DisplayNotification(string message)
        {
            var point = new Point(this.Height, this.Width);
            var not = new NotificationWindow(message, point);
            not.Show();
        }
        private void ListButton_Click(object sender, EventArgs e)
        {
            //DisplayNotification("��");
            try
            {
                ResultRichTextBox.Clear();
                if (figureList.Count == 0)
                {
                    ResultRichTextBox.Text = "���� �� �� ������ ����� ������";
                    return;
                }
                ResultRichTextBox.Text += "Գ����:";
                foreach (var listItem in figureList)
                {
                    if (listItem.Type == FigureEnum.rectangle)
                    {
                        Figures.Rectangle item = listItem as Figures.Rectangle;
                        ResultRichTextBox.Text += $"\n����������� � ���������: {item.a}, {item.b}";
                    }
                    else if (listItem.Type == FigureEnum.triangle)
                    {
                        Figures.Triangle item = listItem as Figures.Triangle;
                        ResultRichTextBox.Text += $"\n��������� � ���������: {item.a}, {item.b}, {item.c}";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}\n\nStack trace:\n{ex.StackTrace}"); }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            ResultRichTextBox.Text = "�� ������ �� ������";
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (figureList.Count == 0)
                {
                    throw new ArgumentException("�� �� ������ ����� ������. ���� �� ���� ��������� ����������");
                }

                ResultRichTextBox.Clear();
                ResultRichTextBox.Text += "��������� �����:";
                foreach (var listItem in figureList)
                {
                    if (listItem.Type == FigureEnum.rectangle)
                    {
                        var item = listItem as Figures.Rectangle;
                        ResultRichTextBox.Text += $"\n{item} �� ����������: {item.CalculateP()}";
                    }
                    else if (listItem.Type == FigureEnum.triangle)
                    {
                        var item = listItem as Figures.Triangle;
                        ResultRichTextBox.Text += $"\n{item} �� ����������: {item.CalculateP()}";
                    }
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}