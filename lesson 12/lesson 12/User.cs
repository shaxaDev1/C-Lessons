class User
{
    public string Name;
    public int Step;
    public long ChatId;

    public User ( long chatId, string name)
    {
        Name = name;
        ChatId = chatId;
        Step = 0; 
    }
    public void SetStep(int setp)
    {
        Step = setp;
    }
    public User (string name, int step, long chatId)
    {
        Name = name;
        Step = step;
        ChatId = chatId;
    }

    public string ToText()
    {
        return $"Id: {ChatId}, Name: {Name}, Step: {Step}";
    }
}