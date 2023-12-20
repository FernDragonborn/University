namespace Lab8
{
    public partial class NotificationWindow : Form
    {
        System.Timers.Timer timer = new(2000);
        public NotificationWindow(string Text, Point position)
        {
            PreInit(Text, position);
            InitializeComponent();
            NotifyLabel.Text = Text;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            this.Invoke((MethodInvoker)(() => Close()));
            timer.Dispose();
        }

    }
}
