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
            InitializeComponent();
            this.Hide();
            JobManager.Initialize();
            JobManager.AddJob(
                this.DoScheduledWork,
                schedule => schedule.ToRunEvery(1).Days().At(14, 0));
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
            this.Hide();
        }
    }
}