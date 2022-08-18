
class QuestionDatabase
{
    public List<Question> Questions = new List<Question>();

    

    public void RemoveQuestion(int index)
    {
        //if(index - 1 > Questions.Count)
           // return;
        
        Questions.RemoveAt(index);
    }
    public void Clear()
    {
        Questions.Clear();
    }
    public string AddQuestion()
    {
        var Text = "Savolni shu holada kiriting \n";
        Text += "5 * 9 = ?, 3, 44, 34 ,46, 45 ";
        return Text;
    }
    public void DfultQuestion()
    {
        Questions.Add(new Question("3 * 4 = ?", 1, new List<string>() { "21", "12", "11", "3" }));
        Questions.Add(new Question("3 * 4 = ?", 1, new List<string>() { "21", "12", "11", "3" }));
        Questions.Add(new Question("3 * 4 = ?", 1, new List<string>() { "21", "12", "11", "3" }));
    }
    public string SaveQuestion(string question)
    {
        var Arr = question.Split(',');
        if (Arr.Length <= 4) return null;

        Questions.Add(new Question(Arr[0], int.Parse(Arr[1]), Arr.Skip(2).ToList()));
        return "Savol qo'shildi";
    }
    //getAllQuestion
    public string GetAllQuestion()
    {
        string message = $"Savollar soni {Questions.Count} ta \n";
        if (Questions.Count > 0)
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                message += $"{i + 1}. {Questions[i].QuestionText}\n";
            }
            return message;
        }
        else return "Bazada savollar yoq";
    }
}
