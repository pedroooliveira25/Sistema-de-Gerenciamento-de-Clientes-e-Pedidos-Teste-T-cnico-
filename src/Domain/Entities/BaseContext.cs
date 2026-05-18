using System.Data;
using Domain.Enums;

namespace Domain.Entities; 


public abstract class Base : Notifications
{   

    public Guid Id {get; protected set;} = Guid.NewGuid();
    public Guid UpdateBy {get; protected set;}
    public DateTime UpdateDate {get; protected set;}
    public StageAccount Status {get; protected set;}
    public string Name {get; protected set;} 
    public string Email {get; protected set;}


}