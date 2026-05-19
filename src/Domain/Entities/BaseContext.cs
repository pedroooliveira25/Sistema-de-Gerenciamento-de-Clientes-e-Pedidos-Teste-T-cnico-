using System.ComponentModel.DataAnnotations;
using System.Data;
using Domain.Enums;

namespace Domain.Entities; 


public abstract class Base : Notifications
{   
    [Display(Name = "Codigo")]
    public Guid Id {get; protected set;} = Guid.NewGuid();

    [Display(Name = "Codigo")]
    public Guid UpdateBy {get; protected set;}

    [Display(Name = "Data/Hora")]
    public DateTime UpdateDate {get; protected set;}

    [Display(Name = "Status")]   
     public StageAccount Status {get; protected set;}
    
    [Display(Name = "Name")]
    public string? Name {get; protected set;} 

    [Display(Name = "Email")]
    public string? Email {get; protected set;}


}