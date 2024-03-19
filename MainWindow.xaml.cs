using FluentScheduler;
using System.Windows;
using System.Windows.Input;

namespace RitalinReminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var today = DateTime.Today.AddHours(14); // 2pm
            InitializeComponent();
            this.Hide();
            JobManager.AddJob(
                this.DoScheduledWork,
                schedule => schedule.ToRunOnceAt(today).AndEvery(1).Days());
            //schedule => schedule.ToRunNow().AndEvery(10).Seconds());
        }

        private void DoScheduledWork()
        {
            Dispatcher.Invoke(new Action(Show));
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}