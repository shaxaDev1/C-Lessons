using Avtotest.Database.Models;
using System.Windows;
using System.Windows.Controls;

namespace AutoSavol.Wpf.Files
{

    public partial class ExaminationResultFile : Page
    {
        public ExaminationResultFile(Ticket ticket)
        {
            InitializeComponent();
            QuestionCount.Text = ticket.QuestionsCount.ToString();
            CorrectAnswer.Text = ticket.CorrectAnswersCount.ToString();
        }

        private void MenuButtonClick(object obj, RoutedEventArgs rea)
        {
            MainWindow.Instance.MainFrame.Navigate(new MainMenuFile());
        }
    }
}
