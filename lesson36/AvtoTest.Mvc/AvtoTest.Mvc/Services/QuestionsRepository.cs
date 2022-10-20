using AvtoTest.Mvc.Models;
using Newtonsoft.Json;

namespace AvtoTest.Mvc.Services;

public class QuestionsRepository
{
    private static QuestionsRepository? _instance = null;
    public static QuestionsRepository Instance {
        get 
        {
            if (_instance == null)
            {
                _instance = new QuestionsRepository();
            }

            return _instance;
        }
        }


    public List<QuestionBase> Questions { get; set; }
    public int TicketQuestionsCount = 10;

    public QuestionsRepository()
    {
        LoadQuestionsFromJsonFile();
    }
    public void LoadQuestionsFromJsonFile()
    {
        var jsonStringData = File.ReadAllText("JsonData/uzlotin.json");

        Questions = JsonConvert.DeserializeObject<List<QuestionBase>>(jsonStringData);
    }
    public int GetTicketsCount()
    {
        return Questions.Count / TicketQuestionsCount;
    }
    public List<QuestionBase> GetQuestionsRange(int from, int count)
    {
        return Questions.Skip(from).Take(count).ToList();
    }

    public List<QuestionBase> GetTicketQuestions(int tIndex)
    {
        int from = tIndex * TicketQuestionsCount;
        return Questions.Skip(from).Take(TicketQuestionsCount).ToList();
    }
}
