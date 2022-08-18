

User user1 = new User();
user1.Name = "Palonchiev Shaxzod";
user1.Id = "Bootcamp 003";
user1.phoneNumber = "+9989074534";
Console.WriteLine($"{user1.Name} => {user1.phoneNumber}");
struct User
{
    public string Name;
    public string Id;
    public string phoneNumber;

    public User(string name,string id,string phonenumber)
    {
        Name = name;
        Id = id;
        phoneNumber = phonenumber;
    }
}
