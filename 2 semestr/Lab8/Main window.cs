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
                MessageBox.Show($"Здається, ви не написали жодної сторони для фігури!\n\nException:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex) { MessageBox.Show($"Здається, ви не написали жодної сторони для фігури!\n\nException:\n{ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
            //DisplayNotification("тт");
            try
            {
                ResultRichTextBox.Clear();
                if (figureList.Count == 0)
                {
                    ResultRichTextBox.Text = "Поки ви не додали жодної фігури";
                    return;
                }
                ResultRichTextBox.Text += "Фігури:";
                foreach (var listItem in figureList)
                {
                    if (listItem.Type == FigureEnum.rectangle)
                    {
                        Figures.Rectangle item = listItem as Figures.Rectangle;
                        ResultRichTextBox.Text += $"\nПрямокутник зі сторонами: {item.a}, {item.b}";
                    }
                    else if (listItem.Type == FigureEnum.triangle)
                    {
                        Figures.Triangle item = listItem as Figures.Triangle;
                        ResultRichTextBox.Text += $"\nТрикутник зі сторонами: {item.a}, {item.b}, {item.c}";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}\n\nStack trace:\n{ex.StackTrace}"); }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            ResultRichTextBox.Text = "Ви стерли всі фігури";
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (figureList.Count == 0)
                {
                    throw new ArgumentException("Ви не додали жодної фігури. Нема на чому проводити розрахунки");
                }

                ResultRichTextBox.Clear();
                ResultRichTextBox.Text += "Периметри фігур:";
                foreach (var listItem in figureList)
                {
                    if (listItem.Type == FigureEnum.rectangle)
                    {
                        var item = listItem as Figures.Rectangle;
                        ResultRichTextBox.Text += $"\n{item} та периметром: {item.CalculateP()}";
                    }
                    else if (listItem.Type == FigureEnum.triangle)
                    {
                        var item = listItem as Figures.Triangle;
                        ResultRichTextBox.Text += $"\n{item} та периметром: {item.CalculateP()}";
                    }
                }
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}