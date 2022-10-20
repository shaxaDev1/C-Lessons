using Microsoft.Data.Sqlite;
using lesson35.Models;

namespace lesson35.Services;

public  class UsersService
{
    private  const string ConnectionString = "Data source=users.db";
    private SqliteConnection connection;
    private SqliteCommand command;
    public UsersService()
    {
        OpenConnection();
        CreateUsersTable();
    }
    public void OpenConnection()
    {
        connection = new SqliteConnection(ConnectionString);
        connection.Open();
        command = connection.CreateCommand();
    }
    public  void CreateUsersTable()
    {
        command.CommandText = "create table if not exists users(id integer primary key autoincrement, name text, phone text)";
        command.ExecuteNonQuery();
    }
    public void InsertUser(User user)
    {
        command.CommandText = $"INSERT INTO users(name , phone) VALUES('{user.Name}','{user.Phone}')";
        command.ExecuteNonQuery();
    }
    public List<User> GetUsers()
    {
        var users = new List<User>();
        command.CommandText = "SELECT * FROM users";
        var  data = command.ExecuteReader();

        while (data.Read())
        {
            var user = new User();

            user.Index = data.GetInt32(0);
            user.Name = data.GetString(1);
            user.Phone = data.GetString(2);

            users.Add(user);
        }
        return users;
    }
    public User GetUserByIndex(int index)
    {
        var user = new User();
        command.CommandText = $"SELECT * FROM users WHERE id = {index}";
        var data = command.ExecuteReader();

        while (data.Read())
        {

            user.Index = data.GetInt32(0);
            user.Name = data.GetString(1);
            user.Phone = data.GetString(2);

        }
        return user;
    }

    public void DeleteUser(int index)
    {
        command.CommandText = $"DELETE FROM users WHERE id = {index}";
        command.ExecuteNonQuery();
    }
    public void UpdateUser(User user)
    {
        command.CommandText = $"UPDATE users SET name = '{user.Name}', phone='{user.Phone}' WHERE id = '{user.Index}'";
        command.ExecuteNonQuery();
    }

}
    