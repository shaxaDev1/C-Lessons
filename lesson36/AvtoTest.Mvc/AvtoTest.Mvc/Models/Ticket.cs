namespace AvtoTest.Mvc.Models;

public class Ticket
{
    public int Index;

    public int CorrectAnswersCount;
    public int QuestionsCount;


    public List<QuestionBase> Questions;

    public List<TicketData> SelectedQuestionIndexs;
    public bool IsQuestionCompleted(int questionIndex)
    {
        return SelectedQuestionIndexs.Any(td => td.QuestionIndex == questionIndex);
    }
    public bool IsChoiceCompleted(int questionIndex, int choiceIndex)
    {
        return SelectedQuestionIndexs.Any(td => td.QuestionIndex == questionIndex && td.SelectdChoiceIndex == choiceIndex);
    }
    public bool TicketCompleted
    {
        get
        {
            return CorrectAnswersCount == QuestionsCount;
        }
    }



    public Ticket(int index, List<QuestionBase> questions)
    {
        Index = index;
        Questions = questions;
        SelectedQuestionIndexs = new List<TicketData>();
        QuestionsCount = questions.Count;
    }

    public Ticket(int index, int correctAnswersCount, int questionsCount)
    {
        Index = index;
        CorrectAnswersCount = correctAnswersCount;
        QuestionsCount = questionsCount;
    }
    public Ticket()
    {

    }

}
public class TicketData
{
    public int QuestionIndex;
    public int SelectdChoiceIndex;

    public TicketData(int questionIndex, int selectdChoiceIndex)
    {
        QuestionIndex = questionIndex;
        SelectdChoiceIndex = selectdChoiceIndex;
    }
}


