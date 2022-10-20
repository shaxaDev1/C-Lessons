using AutoSavol.Wpf.Files;
using Avtotest.Database;
using System.Windows;

namespace AutoSavol.Wpf;

public partial class MainWindow : Window
{
    public static MainWindow Instance;
    public QuestionsRepository QuestionsRepository;
    public TicketsRepository TicketsRepository;
    public int AllCount;
    public MainWindow()
    {
        InitializeComponent();
        Instance = this;

        QuestionsRepository = new QuestionsRepository();
        TicketsRepository = new TicketsRepository();

        var menuFile = new MainMenuFile();
        MainFrame.Navigate(menuFile);
        
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        TicketsRepository.WriteToJson();
    }
}
