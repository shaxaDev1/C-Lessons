using System.Collections.Generic;

namespace AftoTect.WPF.Models;

public class Ticket
{

    public string Text { get; set; }
    public int Index { get; set; }
    public int QuestionsCount { get; set; }
    public int CorrectAnswersCount { get; set; }
    public List<QuestionBase> Questions { get; set; }

    public bool IsCompleted
    {
        get
        {
            return QuestionsCount == CorrectAnswersCount;
        }
    }
    public int CurrentQuestion
    {
        get
        {
            return QuestionsCount - Questions.Count;
        }
    }

    public Ticket(List<QuestionBase> questions)
    {
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
    }
    public Ticket( int index, List
        
        <QuestionBase> questions)
    {
        QuestionsCount = questions.Count;
        CorrectAnswersCount = 0;
        Questions = questions;
        Index = index;
    }
    public Ticket(int index , string text)
    {
        Text = text;
        Index = index;
    }
}
