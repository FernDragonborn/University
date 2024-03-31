using System.Windows;

namespace Lab_01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 logoWindow = new();
            logoWindow.Show();

        }
    }
}