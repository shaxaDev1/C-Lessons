using Microsoft.Data.Sqlite;

var sqlite = new SqliteConnection("Data Source=school.db");


sqlite.Open();

var command  = sqlite.CreateCommand();
command.CommandText = "create table books(" +
    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
    "name TEXT," +
    "aouthor TEXT)";

//command.ExecuteNonQuery();
command.CommandText = "create table students(" +
    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
    "name TEXT," +
    "gruh TEXT," +
    "phone TEXT)";
//command.ExecuteNonQuery();

command.CommandText = "INSERT INTO books (name ,aouthor) VALUES('Csharp','Microsoft')";
command.ExecuteNonQuery();

command.CommandText = "INSERT INTO students (name ,gruh , phone) " +
    "VALUES('Csharp','Microsoft','2323')";
command.ExecuteNonQuery();

var reader = sqlite.CreateCommand();
reader.CommandText = "select * from books";
var data = reader.ExecuteReader();

while (data.Read())
{
    var book = $"id: {data.GetInt32(0)}," +
        $"name:{data.GetString(1)}," +
        $"author: {data.GetString(2)}";
    Console.WriteLine(book);   
}