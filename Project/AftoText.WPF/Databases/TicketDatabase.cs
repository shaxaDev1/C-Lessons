
using AftoTect.WPF.Models;
using AftoTect.WPF.Options;
using System;
using System.Collections.Generic;

namespace AftoTect.WPF.Databases;

public class TicketDatabase
{
    public  List<Ticket> UserTickets { get; set; }
   

    public TicketDatabase()
    {
        UserTickets = new  List<Ticket>();
    }
    public Ticket CreateTicket()
    {
        return  new Ticket( CreateExamTicket());  
        
    }
    public List<QuestionBase> CreateExamTicket()
    {
        int randomNumer = new Random().Next(0, GetTicketsCount());
        var questions = Database.Db.Questions_Db.CreateTicket(randomNumer * TicketsSettings.TicketQuestionsCount, TicketsSettings.TicketQuestionsCount);
        return new List<QuestionBase>(questions);
    }
    
    
    public int GetTicketsCount()
    {
        return Database.Db.Questions_Db.Questions.Count / TicketsSettings.TicketQuestionsCount;
    }
   
}
