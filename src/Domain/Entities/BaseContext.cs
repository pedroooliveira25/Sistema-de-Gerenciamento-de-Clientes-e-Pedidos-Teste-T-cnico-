using System.ComponentModel.DataAnnotations;
using System.Data;
using Domain.Enums;

namespace Domain.Entities; 


public abstract class Base : Notifications
{   
    [Display(Name = "Code")]
    public Guid Id {get; protected set;} = Guid.NewGuid();

    [Display(Name = "Updated by")]
    public Guid UpdateBy {get; protected set;}

    [Display(Name = "Update Date/Time")]
    public DateTime UpdateDate {get; protected set;} = DateTime.UtcNow;
    


}