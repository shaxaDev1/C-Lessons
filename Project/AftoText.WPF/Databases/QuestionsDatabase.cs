


using AftoTect.WPF.Models;
using System.Collections.Generic;
using System.Linq;

namespace AftoTect.WPF.Databases;

public class QuestionsDatabase
{
    public List<QuestionBase> Questions { get; set; }
    public QuestionsDatabase(List<QuestionBase> questions)
    {
        Questions = questions;
    }
    public List<QuestionBase> CreateTicket(int form = 0, int questinsCount = 20)
    {
        return Questions.Skip(form).Take(questinsCount).ToList();
    }
}
    
