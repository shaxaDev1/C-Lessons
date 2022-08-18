
class Database
{
    public QuestionDatabase questiondb;
    public UserDatabase userdb;
    public Database()
    {
        questiondb = new QuestionDatabase();
        userdb = new UserDatabase();
    }
}