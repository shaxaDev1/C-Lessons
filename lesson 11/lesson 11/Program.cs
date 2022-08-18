
using Telegram.Bot;
using Telegram.Bot.Types;

List<Question> questions = new List<Question>();
AddDefaultQuestion();

Dictionary<long, User> users = new Dictionary<long, User>();

string botToken = "5706935992:AAG_FlaASvDc-KFx84tf4L4hsj4UIsuuhJc";
TelegramBotClient bot = new TelegramBotClient(botToken);

bot.StartReceiving(
   updateHandler: (client, update, token) => GetUpdate(update),
   errorHandler: (client, exception, token) => Task.CompletedTask );

Console.ReadKey();

async Task GetUpdate(Update update)
{
    Console.Write(update.Message.Text);
    var text = update.Message.Text;
    var chatId = update.Message.Chat.Id;

    if (!users.ContainsKey(chatId))
    {
        string name = string.IsNullOrEmpty(update.Message.From.Username)
            ? update.Message.From.FirstName
            : "@" + update.Message.From.Username;

        SaveUser(chatId, name, 0);
    }
    if (users[chatId].Step == 2)
    {
        AddNewQuestion(chatId, text!);  
    }
    switch (text)
    {
        case "menu":
            
            ShowMenu(chatId); break;
        case "2":
            AddQuestion(chatId); break;
        case "3":
            ShowDashboard(chatId); break;
        
    }
}


void SendMessage(long chatId, string messageText)
{
    bot.SendTextMessageAsync(chatId, messageText);
}

void ShowMenu(long chatId)
{
   var menu = new List<Menu>()
   {
       Menu.StartQuiz,
       Menu.AddQustion,
       Menu.Dashboard,
       Menu.Statistics,
       Menu.Users,
       Menu.Close

   };
    string menuText = "";

    foreach(var Menu in menu)
    {
        menuText += $"{(int)Menu}. {Menu}\n";
    }
    SendMessage(chatId, menuText);
}

void AddDefaultQuestion()
{
    questions.Add(new Question4("3 * 4 = ?", 1, new List<string>() { "21", "12", "11", "3" }));
    questions.Add(new Question("15 / 3 = ?", 2, new List<string>() { "6", "7", "5", "12" }));
    questions.Add(new Question("21 % 4 = ?",3, new List<string>() { "0", "5","3", "1"}));
}



void ShowDashboard(long chatId)
{
    string message = "Savollar " + questions.Count + " ta.\n";
    string questionsText = "";
    for(int i = 0; i < questions.Count; i++)
    {
        questionsText += $"{i + 1}. {questions[i].QuestionText}\n";
    }

    message += questionsText;
    message += "\n Menuga qaytish uchun 'menu' deb kiriting";

    SendMessage(chatId, message);
   
}

void AddQuestion(long chatId)
{
    string addQuetionText = "Savolni shu holatta kiriting :";
    addQuetionText += "5 * 9 = ?, 3, 44, 34 ,46, 45 ";
    

    SendMessage(chatId, addQuetionText);

    SetStep(chatId, 2);
}

void SaveUser(long chatId, string name, int step)
{
    users.Add(chatId, new User(chatId, name, step));
}

void ShowUsers(long chatId)
{
    var message = "Foydalanuvchilar royxati: \n";
    var usersText = "";

    for(int i = 0; i < users.Values.Count; i++)
    {
        usersText += users.Values.ElementAt(i).ToText() + "\n";
    }
    message += usersText;

    SendMessage(chatId, message);
}
void SetStep(long chatId , int step)
{
    var user = users[chatId];
    user.SetStep(step);
    users[chatId] = user;
}
void AddNewQuestion(long chatId, string question)
{
    string[] questionArr = question.Split(',');
    if(questionArr.Length >= 4 )
    {
        Question newQuestion = new Question ( questionArr[0],
        int.Parse(questionArr[1]), questionArr.Skip(2).ToList());
        questions.Add(newQuestion);
        SendMessage(chatId , "Savol qoshildi.");
        SetStep(chatId, 0);
        return;

    }
    AddQuestion(chatId);
}
