
using Avtotest.Database;
using Avtotest.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace AutoSavol.Wpf.Files;

public partial class ExaminationFile : Page
{
    private int currentQuestionIndex = 0;
    private Ticket currentTicket;
    public ExaminationFile(int currentTicketIndex = -1 )
    {
        InitializeComponent();

        if(currentTicketIndex <= -1)
        { 
            var random = new Random();
            currentTicketIndex = random.Next(0, MainWindow.Instance.QuestionsRepository.GetTicketsCount());
        }
        Titel.Content = $"Ticket{currentTicketIndex + 1}";
        CreateTicket(currentTicketIndex);
        GenerateTicExamQuestionIndexButtons();
        ShowQuestion();
    }

    private void GenerateTicExamQuestionIndexButtons()
    {
        for(int i = 0; i < currentTicket.QuestionsCount; i++)
        {
            var button = new Button();
            if(i == 0)
            {
                button.Style = FindResource("CurrentTicketQuestionButtonStyle") as Style;
            }
            else
            {
                button.Style = FindResource("DefoultTicketQuestionButtonStyle") as Style;
            }
            
            button.Content = i + 1;
            button.Tag = i;
            button.Click += TicExamQuestionIndexButtonClick;

            TicExamQuestionIndexButtonFile.Children.Add(button);
        }
    }

    private void TicExamQuestionIndexButtonClick(object obj, RoutedEventArgs e)
    {
        var button = obj as Button;
        button.Style = button.Style = FindResource("CurrentTicketQuestionButtonStyle") as Style;
        var oldButton = TicExamQuestionIndexButtonFile.Children[currentQuestionIndex] as Button;
        oldButton.Style = FindResource("DefoultTicketQuestionButtonStyle") as Style;
        var questionIndex = (int)button.Tag;
        currentQuestionIndex = questionIndex;
        ShowQuestion();
        
    }

    private void CreateTicket(int ticketIndex )
    {
        var ticketQuestionsCount = MainWindow.Instance.QuestionsRepository.TicketQuestionsCount;
        var from = ticketIndex * ticketQuestionsCount;
        var ticketQuestions = MainWindow.Instance.QuestionsRepository.GetQuestionsRange(from, ticketQuestionsCount);
        currentTicket = new Ticket(ticketIndex, ticketQuestions);
    }

   
    private void MenuButton(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MainMenuFile());
    }
    private void ShowQuestion()
    {
        var question = currentTicket.Questions[currentQuestionIndex];

        QuestionText.Text = $"{currentQuestionIndex + 1}. {question.Question}";
        LoadQuestionImage(question.Media);
        GenerateChoiceButton(question.Choices);
    }

    private void LoadQuestionImage(Media questionMedia)
    {
        string imagePath;
        if (questionMedia.Exist)
            imagePath = Path.Combine(Environment.CurrentDirectory, "Images", $"{questionMedia.Name}.png");
        else
            imagePath = Path.Combine(Environment.CurrentDirectory, "Images", "noImage.png");

        QuestionImages.Source = new BitmapImage(new Uri(imagePath));
    }

    private void GenerateChoiceButton(List<Choice> choices)
    {

        ChoicesFile.Children.Clear();
        for (int i = 0; i < choices.Count; i++)
        {
            var choice = choices[i];
            var button = new Button();
            
            if (currentTicket.IsChoiceCompleted(currentQuestionIndex, i))
            {
                if (choice.Answer)
                {
                    button.Background = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                }
            }
            button.Width = 350;
            button.MinHeight = 30;
            button.FontSize = 16;
            button.Margin = new Thickness(2);
            choice.Index = i;
            button.Tag = choice;
            button.Click += ChoiceButtonClick;

            //button.Content = choice.Text;
            var textBlock = new TextBlock();
            textBlock.Text = choice.Text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            button.Content = textBlock;

            ChoicesFile.Children.Add(button);
        }

    }
    private void ChoiceButtonClick(object obj, RoutedEventArgs rea)
    {
        if (currentTicket.IsQuestionCompleted(currentQuestionIndex)) return;
        var button = obj as Button;
        var choice = (Choice)button.Tag;
        if (choice.Answer)
        {
            button.Background = new SolidColorBrush(Colors.Yellow);
            (TicExamQuestionIndexButtonFile.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.Yellow);
            currentTicket.CorrectAnswersCount++;
            MainWindow.Instance.AllCount++;
        }
        else
        {
            button.Background = new SolidColorBrush(Colors.Red);
            (TicExamQuestionIndexButtonFile.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.Red);
        }
        
        currentTicket.SelectedQuestionIndexs.Add(new TicketData( currentQuestionIndex, choice.Index));

        if(currentTicket.SelectedQuestionIndexs.Count == currentTicket.QuestionsCount)
        {
            var ticketsRepository = MainWindow.Instance.TicketsRepository;
            var IsCopletedTicket = ticketsRepository.UserTickets.Any(ut => ut.Index == currentTicket.Index);
            if (IsCopletedTicket)
            {
                var oldTicket = ticketsRepository.UserTickets.First(ut => ut.Index == currentTicket.Index);
                ticketsRepository.UserTickets.Remove(oldTicket);
            }
            ticketsRepository.UserTickets.Add(currentTicket);
            MainWindow.Instance.MainFrame.Navigate(new ExaminationResultFile(currentTicket));
        }
    }
   


}
