using AftoTect.WPF;
using AftoTect.WPF.Pages;
using System;
using System.Windows;

namespace AftoText.WPF
{
    public partial class MainWindow : Window
    {
        private static MainWindow? _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
            MainFrame.Navigate(new MenMenuPages());
        }
        public void DisplayPage(EPage page)
        {
            switch (page)
            {
                case EPage.Examination: MainFrame.Navigate(new ExaminationPages()); break;
                case EPage.Tickets: MainFrame.Navigate(new TicketsPages()); break;
                case EPage.Main: MainFrame.Navigate(new MenMenuPages()); break;
            }
        }
        public void DisplayTicketPage(int ticketIndex)
        {
            MainFrame.Navigate(new ExaminationPages());
            
        }

      
    }
}
