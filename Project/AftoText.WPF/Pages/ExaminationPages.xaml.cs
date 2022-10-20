
using AftoTect.WPF.Databases;
using AftoTect.WPF.Models;
using AftoTect.WPF.Options;
using AftoText.WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AftoTect.WPF.Pages;

public partial class ExaminationPages : Page
{
    private Ticket CurrentTicket;
    private int currentQuestionIndex = 0;
    private Button correctAnswer;
    private DispatcherTimer timer;
    public ExaminationPages(int? ticketIndex = null)
    {
        InitializeComponent();

        //create ticket
        CurrentTicket = ticketIndex == null
            ? Database.Db.Ticket_Db.CreateTicket()
            : CreateTicketByIndex(ticketIndex.Value);

        TicketLabel.Content = ticketIndex != null ? $"Ticket{ticketIndex + 1}" : "Examination";

        ShowQuestion();
        GenerateQuestionIndexButtons();

    }

    
    private void SetImage(string imageName)
    {
        questionImage.Source = new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "Images", $"{imageName}.png")));
    }
    private Ticket CreateTicketByIndex(int ticketIndex)
    {
        var from = ticketIndex * TicketsSettings.TicketQuestionsCount;
        var questions = Database.Db.Questions_Db.CreateTicket(from, TicketsSettings.TicketQuestionsCount);
        var ticket = new Ticket(ticketIndex, new List<QuestionBase>(questions));
        return ticket;
    }
    private void ShowQuestion()
    {
        var question = CurrentTicket.Questions[currentQuestionIndex];
        SetImage(question.Media.Exist ? question.Media.Name : "noImage");
        QuestionText.Text = $"{currentQuestionIndex + 1}. {question.Question}";
        AddButtons(question);
    }
   
   
    private void AddButtons(QuestionBase question)
    {
        ChoicesPanel.Children.Clear();
        int animTime = 0;
        for (int i = 0; i < question.Choices.Count; i++)
        {
            var button = new Button();
            button.Style = FindResource("ChoiceButtonStyle") as Style;
            button.Click += ChoiseSelected;
            button.DataContext = question.Choices[i];

            ChoicesPanel.Children.Add(button);
            animTime += 300;
            StarQuestionChoiceButtonAnimation(animTime, button);
        }
    }
    
    private void GenerateQuestionIndexButtons()
    {
        int animTime = 0;
        for (int i = 0; i < CurrentTicket.Questions.Count; i++)
        {
            var button = new Button();
            button.Style = FindResource("QuestionIndexButtonStyle") as Style;
            button.Content = i + 1;
            button.Tag = i;
            button.Click += QuestionIndexSelected;
            QuestionsIndexPanel.Children.Add(button);

            animTime += 100;

            StartQuestionIndexButtonAnimation(animTime, button);
        }
    }
    public void StartQuestionIndexButtonAnimation(int animTime, Button btn)
    {
        DoubleAnimation animOpacity = new DoubleAnimation
        {
            From = 0,
            To = 1,
            Duration = new Duration(TimeSpan.FromMilliseconds(100)),
            BeginTime = TimeSpan.FromMilliseconds(animTime),
        };
        btn.BeginAnimation(Button.OpacityProperty, animOpacity);
    }
    public void StarQuestionChoiceButtonAnimation(int animTime, Button btn)
    {
        DoubleAnimation animOpacity = new DoubleAnimation
        {
            From = 0,
            To = 1,
            Duration = new Duration(TimeSpan.FromMilliseconds(300)),
            BeginTime = TimeSpan.FromMilliseconds(animTime),
        };
        ThicknessAnimation animLeft = new ThicknessAnimation();
        animLeft.From = new Thickness(10, 20, 10, 10);
        animLeft.To = new Thickness(10, 0, 10, 10);
        animLeft.Duration = new Duration(TimeSpan.FromMilliseconds(100));

        btn.BeginAnimation(Button.OpacityProperty, animOpacity);
        btn.BeginAnimation(Button.MarginProperty, animLeft);
    }
    private void QuestionIndexSelected(object sender, RoutedEventArgs e)
    {
        currentQuestionIndex = (int)(sender as Button)!.Tag;
        ShowQuestion();
    }
    private void ChoiseSelected(object sender, RoutedEventArgs e)
    {
        if (CurrentTicket.Questions[currentQuestionIndex].IsCompleted) return;

        var button = (Button)sender;
        var bag = (Choice)button.DataContext;
        if (bag.Answer)
        {
            button.Background = new SolidColorBrush(Colors.LightGreen);
            CurrentTicket.CorrectAnswersCount++;
            (QuestionsIndexPanel.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.LightGreen);
        }
        else
        {
            button.Background = new SolidColorBrush(Colors.Red);
            (QuestionsIndexPanel.Children[currentQuestionIndex] as Button)!.Background = new SolidColorBrush(Colors.Red);

        }
        CurrentTicket.Questions[currentQuestionIndex].IsCompleted = true;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.DisplayPage(EPage.Main);
    }


    private void SetVisibility(StackPanel panel, bool isVisible)
    {
        panel.Visibility = isVisible ? Visibility.Visible : Visibility.Hidden;
        panel.IsEnabled = isVisible;
    }
    
    private void CloseTicket(object sender, RoutedEventArgs e)
    {
        SetVisibility(ExamResultPanel, true);
        SetVisibility(QuestionPanel, false);
        ExamResultPanel.DataContext = CurrentTicket;
        Database.Db.Ticket_Db.UserTickets.Add(CurrentTicket);
    }


}
