

using EntityframeworkSample;

var dbContext = new AppDbContext();

foreach(var question in dbContext.Questions)
{
    Console.WriteLine($"{question.Id},{question.Text}");
}