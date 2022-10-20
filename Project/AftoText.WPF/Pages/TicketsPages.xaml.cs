using AftoTect.WPF.Databases;
using AftoTect.WPF.Models;
using AftoText.WPF;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AftoTect.WPF.Pages;

public partial class TicketsPages : Page
{
    public TicketsPages()
    {
        InitializeComponent();
        GenerateTicketButton();
    }

    private void GenerateTicketButton()
    {
        TicketButtonPanel.Children.Clear();
        for(int i = 0; i < Database.Db.Ticket_Db.GetTicketsCount(); i++)
        {
            var button = new Button();
            button.Template = FindResource("TicketButtonTemplate") as ControlTemplate;

            button.Click += StartTicket;

            if (Database.Db.Ticket_Db.UserTickets.Any(t => t.Index == i))
            {
                var ticket = Database.Db.Ticket_Db.UserTickets.First(t => t.Index == i);
                ticket.Text = ticket.IsCompleted ? $"Ticket{i+1} ✅" : $"Ticket{i + 1}{ticket.CorrectAnswersCount}/{ticket.QuestionsCount}";
                button.DataContext = ticket;
            }
            else
            {
                button.DataContext = new Ticket(i, $"Ticket{i + 1}"); 
            }
            TicketButtonPanel.Children.Add(button);
        }
    }
    private void StartTicket(object sender, RoutedEventArgs e)
    {
        var data = (Ticket)(sender as Button)!.DataContext;
        MainWindow.Instance.DisplayTicketPage(data.Index);
    }

    private void MainMenu(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Main);
    }
}
