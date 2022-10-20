using Avtotest.Database.Models;
using Newtonsoft.Json;

namespace Avtotest.Database;

public class QuestionsRepository
{
    public List<QuestionBase> Questions { get; set; }
    public int TicketQuestionsCount = 5;

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
}
