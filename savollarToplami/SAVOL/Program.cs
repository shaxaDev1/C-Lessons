
List<string[]> questions = new List<string[]>();
var statistics = new List<Tuple<string, int>>()
{ 
    new Tuple<string, int>("Asqar", 100),
    new Tuple<string, int>("Murot", 20),
    new Tuple<string, int>("Samandar" , 40)
};

Dictionary<string, string> languagesapp;


var parol = "12222001";
AddDefaultQuestions(questions);


Start();

void ChooseMenu()
{
    var input = (Menu)int.Parse(Console.ReadLine()!);
    switch (input)
    {
        case Menu.StartQuiz: StartQuiz(); break;
        case Menu.AddQuestion: AddQuestion(); break;
        case Menu.Dashbord: Dashbord(); break;
        case Menu.Statistics: Statistics(); break;
        case Menu.Close: return;
        default: 
            {
                Console.WriteLine("Mavjud bolmagan Menu tanladingiz");
                Start();
            } break;
    }

}
void StartQuiz()
{
    Console.Write("Ismingizni kiriting :");
    var  name = Console.ReadLine();

    int togriJavoblarSoni = 0;
    var wrongList = new List<Tuple<string , string, string>>();

    for (var j = 0; j < questions.Count; j++)
    {
        for (var i = 0; i < questions[j].Length; i++)
        {
            if (i == 0)
            {
                Console.WriteLine($"Savol : {questions[j][i]}");
            }
            else if (i != 1) Console.WriteLine($"{i - 1}. {questions[j][i]}");
        }
        Console.WriteLine("Javobini kiriting:");
        var answer = int.Parse(Console.ReadLine()!) + 1;

        if (answer.ToString() == questions[j][1])
        {
            togriJavoblarSoni++;
            Console.WriteLine("Javob togri");
        }
        else
        {
            var correctIndex = int.Parse(questions[j][1]);
            var wrong = new Tuple<string, string, string>
                (questions[j][0], questions[j][correctIndex], questions[j][answer]) ;
            wrongList.Add(wrong);
            Console.WriteLine("Javob notogri");
        }

            if (questions.Count - 1 == j)
            Console.WriteLine("Natijani korish uchun ***Entrni*** bosing");
        else Console.WriteLine("Davom etitish uchun ***Entrni*** bosing");

        Console.ReadKey();

    }
    Console.WriteLine("Togri javoblar soni : {0}", togriJavoblarSoni);

    foreach (var wrong in wrongList)
    {
        Console.WriteLine($"Savol :{wrong.Item1}, " +
                          $"Togri javob: {wrong.Item2}, " +
                          $"Siz kiritgan javob: {wrong.Item3}");
    }

    var user = new Tuple<string, int>(name!, (int)((double)togriJavoblarSoni / questions.Count * 100));
    statistics!.Add(user);

    Console.WriteLine("Menu uchun 'Enter' bosing.");
    Console.ReadKey();
    Start();

}
void AddQuestion()
{
    Console.Write("Parolni kiriting : ");
    var tekshirish = Console.ReadLine();
    if(tekshirish != parol)
    {
        Console.WriteLine("Parolingiz notogri");
        Start();
    }
    Console.WriteLine("Savolni kiriting");
    var newQuestion = Console.ReadLine()!;


    Console.WriteLine("Variantlarni kiriting.");
    Console.WriteLine("Massalon: javob 3, 5 variant,  yetti, 9");

    var choices = Console.ReadLine()!.Split(',');

    Console.WriteLine("Togri javob indeksini kiriting");
    var correctAnswerIndex = int.Parse(Console.ReadLine()!) + 1;

    var savol = new string[2 + choices.Length];
    savol[0] = newQuestion;
    savol[1] = correctAnswerIndex.ToString();
    for (var i = 0; i < choices.Length; i++)
    {
        savol[i + 2] = choices[i];
    }
    questions.Add(savol);
    Console.WriteLine("Savol qoshildi.");
    Start();
}
void Dashbord()
{
    foreach(var question in questions)
        Console.WriteLine(question[0]);

    Console.WriteLine($"Mavjud savollar soni {questions.Count}");
    Start();
}
void Statistics()
{
    Console.WriteLine("Statistics : ");
    ShowMenuStatistics();
    var input = (Menu)int.Parse(Console.ReadLine()!);
    switch (input)
    {
        case Menu.Show: ShowStatistics();break;
        case Menu.Clear: ClearStatistics(); break;
    }
    void ShowStatistics()
    {
        if (statistics!.Count > 0)
        {
            statistics = statistics.OrderByDescending(element => element.Item2).ToList();
            for (var i = 0; i < statistics.Count; i++)
            {
                var (ism, togriJavoblarFoizi) = statistics[i];
                Console.WriteLine($"{i + 1}. {ism} {togriJavoblarFoizi}%");
            }
        }
        else
        {
            Console.WriteLine("Hichkim ishlamadi");
        }
        Console.WriteLine("Menu uchun ***Enter*** bosing");
        Console.ReadKey();

        Start();
    }
    void ClearStatistics()
    {
        statistics.Clear();
        Console.WriteLine("Cleared.");
        Start();
    }
    
}

void AddDefaultQuestions(List<string[]> questions)
{
    questions.Add(new[]{ "2 + 4 = ?", "2", "6", "5", "9" });
    questions.Add(new[]{ "10 - 4 = ?", "3", "7", "6", "19" });
    questions.Add(new[]{ "4 * 4 = ?", "4", "6", "5", "16" });
    questions.Add(new[]{ "20 / 4 = ?", "3", "6", "5", "9" });


}
void Start()
{
    Console.WriteLine();       
    ShowMenu(Menu.StartQuiz);
    ShowMenu(Menu.AddQuestion);  
    ShowMenu(Menu.Dashbord);
    ShowMenu(Menu.Statistics);
    ShowMenu(Menu.Close);
    ChooseMenu();
}
void ShowMenuStatistics()
{
    Console.WriteLine();
    ShowMenu(Menu.Show);
    ShowMenu(Menu.Clear);
}
void ShowMenu(Menu menu)
{
    Console.WriteLine($"{(int)menu}. {menu}");
}
enum Menu
{
    StartQuiz =1,
    AddQuestion,
    Dashbord,
    Statistics,
    Close,
    Show = 1,
    Clear
}

void GetLanguage()
{
    Console.WriteLine("Tillarni tanlang");
}

