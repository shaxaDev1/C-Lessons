
using AftoTect.WPF.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AftoTect.WPF.Databases;

public class Database
{
    private const string UsersJsonPath = "Data/users.json";
    private const string QuestionsJsonPath = "JsonData/uzlotin.json";

    private  static Database _database;
    public static Database Db
    {
        get
        {
            if(_database == null)
            {
                _database = new Database();
            }
            return _database;
        }
    }
    public Database()
    {

        Questions_Db = new QuestionsDatabase(ReadQuestionsJson());
        Ticket_Db = new TicketDatabase();
    }

    public QuestionsDatabase Questions_Db;
    public TicketDatabase Ticket_Db;
   
    private  List<QuestionBase> ReadQuestionsJson()
    {
        if (!File.Exists(QuestionsJsonPath)) return new List<QuestionBase>();
        var json = File.ReadAllText(QuestionsJsonPath);
        try
        {
            return JsonConvert.DeserializeObject<List<QuestionBase>>(json)!;
        }
        catch
        {
            System.Console.WriteLine("Error");
            return new List<QuestionBase>();
        }
    }
   
    
}
