using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoSavol.Wpf.Files
{
    
    public partial class MainMenuFile : Page
    {
        
        public MainMenuFile()
        {
            InitializeComponent();
            var connpletedQuestionsCount = MainWindow.Instance.AllCount;
            var totalQuestionCount = MainWindow.Instance.QuestionsRepository.Questions.Count;
            QuestionsStatistka.Content = $"{connpletedQuestionsCount}/{totalQuestionCount}";

            var conmpletedTicketsCount = MainWindow.Instance.TicketsRepository.UserTickets.Count(t => t.TicketCompleted);
            var totalTicketCount = MainWindow.Instance.QuestionsRepository.GetTicketsCount();
            TicketsStatistka.Content = $"{conmpletedTicketsCount}/{totalTicketCount}";
            
        }

        public void TicketButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new TicketsFile());
        }


        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new ExaminationFile());
        }
    }
}
