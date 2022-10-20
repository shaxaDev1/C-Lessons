using AvtotestJsonToDbConsole.Models;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

var connection = new SqliteConnection("Data source=avtotest.db");
connection.Open();

var command = connection.CreateCommand();
command.CommandText = "CREATE TABLE IF NOT EXISTS " +
    "questions(id INTEGER PRIMARY KEY AUTOINCREMENT," +
    "question_text TEXT," +
    "description TEXT,"+
    "media TEXT)";
command.ExecuteNonQuery();

command.CommandText = "CREATE TABLE IF NOT EXISTS " +
        "choices(id INTEGER PRIMARY KEY AUTOINCREMENT, "+
        "text TEXT, "+
        "answer BOOLEAN,"+
        "questionId INTEGER)";

command.ExecuteNonQuery();



var jsonData = File.ReadAllText("JsonData/uzlotin.json");

var questions = JsonConvert.DeserializeObject<List<QuestionBase>>(jsonData);

if(questions == null)
{
    Console.WriteLine("Questions Null");
    return;
}
Console.WriteLine(questions?.Count);

foreach(var question in questions)
{
    AddQuestion(question);
}
void AddQuestion(QuestionBase question)
{
    if(question.Media?.Name == null)
    {
        command.CommandText = "INSERT INTO questions(" +
            "id ,question_text, description)" + 
            $" VALUES({question.Id},\"{question.Question}\",\"{question.Description}\")";
    }
    else
    {
        command.CommandText = "INSERT INTO questions(" +
            "id,question_text, description, media)" +
            $" VALUES({question.Id},\"{question.Question}\",\"{question.Description}\",'{question.Media.Name}')";
    }

    command.ExecuteNonQuery();

    AddChoices(question.Choices!, question.Id);
}

void AddChoices(List<Choice>? questionChoices, int questionId)
{
    foreach(var choice in questionChoices)
    {
        command.CommandText = "INSERT INTO choices(" +
            "text,answer, questionId)" +
            $" VALUES(\"{choice.Text}\",{choice.Answer},{questionId})";

        command.ExecuteNonQuery();
    }
}