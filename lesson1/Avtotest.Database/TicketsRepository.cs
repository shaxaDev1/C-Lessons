using Avtotest.Database.Models;
using Newtonsoft.Json;

namespace Avtotest.Database;

public class TicketsRepository
{
    public List<Ticket> UserTickets = new List<Ticket>();

    public TicketsRepository()
    {
        ReadJsonData();
    }

    public void WriteToJson()
    {
        List<Ticket> ticketsData = UserTickets.Select
            (t => new Ticket(t.Index, t.CorrectAnswersCount, t.QuestionsCount)).ToList();

        var jsonData = JsonConvert.SerializeObject(ticketsData);

        if (!Directory.Exists("UserData"))
        {
             Directory.CreateDirectory("UserData");
        }
        File.WriteAllText("UserData/usertickets.json", jsonData);
    }
    public void ReadJsonData()
    {

        var jsonData = File.ReadAllText("UserData/usertickets.json");
        UserTickets = JsonConvert.DeserializeObject<List<Ticket>>(jsonData);
    }
}
