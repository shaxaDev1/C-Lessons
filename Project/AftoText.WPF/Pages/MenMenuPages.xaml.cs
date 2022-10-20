using AftoText.WPF;
using System.Windows;
using System.Windows.Controls;

namespace AftoTect.WPF.Pages
{
    public partial class MenMenuPages : Page
    {
        public MenMenuPages()
        {
            InitializeComponent();
        }

        public void StartExamination(object? sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPage.Examination);
        }
        private void ShowTickets(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.DisplayPage(EPage.Tickets);
        }


    }
}
