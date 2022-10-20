namespace Avtotest.Database.Models;

public class QuestionBase
{
    public int Id;
    public string Question;
    public List<Choice> Choices;
    public Media Media;
    public string Description;
}
public class Choice 
{
    public int Index;
    public string Text;
    public bool Answer;
}
public class Media
{
    public bool Exist;
    public string Name;
}




