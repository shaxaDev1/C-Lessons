using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AutoSavol.Wpf.Files
{
    public partial class TicketsFile : Page
    {
        public TicketsFile()
        {
            InitializeComponent();

            GenerateTicketButton();

        }

        private void GenerateTicketButton()
        {
            var questionsRepository = MainWindow.Instance.QuestionsRepository;
            int ticketsCount = questionsRepository.GetTicketsCount();
            var ticketsRepository = MainWindow.Instance.TicketsRepository;
            for (int i = 0; i < ticketsCount; i++)
            {
                var button = new Button();
                if(ticketsRepository.UserTickets.Any(ticket => ticket.Index == i))
                {
                    var ticket  = ticketsRepository.UserTickets.First(ticket => ticket.Index == i);
                    button.Content = ticket.TicketCompleted ? (i + 1) +"Ticket"+  "\t✅" :
                        (i + 1) + "Ticket" + $"\t{ticket.QuestionsCount}/{ticket.CorrectAnswersCount}";
                }
                else
                {
                    button.Content = (i + 1) +"Ticket" ;
                }
                button.Width = 200;
                button.Height = 40;
                button.FontSize = 16;
                
                button.Click += TicketButtonClick;
                button.Tag = i;
                TicketButtonFile.Children.Add(button);
            }
        }

        private void TicketButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var TicketIndex = (int)button.Tag;

            var examFile = new ExaminationFile(TicketIndex);
            MainWindow.Instance.MainFrame.Navigate(examFile);

        }

        private void MainButton(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new MainMenuFile());
        }
    }
}
