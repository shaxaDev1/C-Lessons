class UserDatabase
{
    public List<User> Users  = new List<User>();

    public void AddUser(long chatId , string name)
    {
        if(Users.Any(user => user.ChatId == chatId))
        {
            return;
        }
        var user  = new User(chatId, name);

        Users.Add(user);
    }

    public User? GetUser(long chatId)
    {
            return Users.FirstOrDefault(user => user.ChatId == chatId);  
    }
}