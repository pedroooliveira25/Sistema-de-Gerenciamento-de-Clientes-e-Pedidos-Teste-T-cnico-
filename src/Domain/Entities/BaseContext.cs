using System.Data;

namespace Domain.Entities; 


public abstract class Base : Notifications
{   

    public Guid Id {get; protected set;}
    public Guid UpdateBy {get; protected set;}
    public DateTime UpdateAt {get; protected set;}
    public StageAccount Status {get; protected set;}
    public string Name {get; protected set;} 
    public string Email {get; protected set;}


}