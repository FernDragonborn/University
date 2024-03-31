using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string textInput = txtInput.Text;

            if (textInput is null || textInput.Length == 0)
            {
                MessageBox.Show("Будь ласка, введіть ім'я");
                return;
            }

            if (!int.TryParse(numInput.Text, out int numberInput))
            {
                MessageBox.Show("Будь ласка, у полі із віком введіть коректне числове значення.", "Помилка");
                return;
            }

            string selectedOption = "";
            try
            {
                selectedOption = cmbOptions.Text.ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Будь ласка, оберіть значення із випадаючого списку");
                return;
            }
            if (selectedOption.Length == 0)
            {
                MessageBox.Show("Будь ласка, оберіть стать");
                return;
            }
            string resultMessage = $"Дякуємо за введення даних. Ви ввели текст '{textInput}', число '{numberInput}' та обрали варіант '{selectedOption}'.";

            MessageBox.Show(resultMessage, "Результат");
        }
    }
}