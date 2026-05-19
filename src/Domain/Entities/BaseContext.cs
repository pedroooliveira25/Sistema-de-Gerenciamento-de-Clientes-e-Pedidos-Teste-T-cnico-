using System.ComponentModel.DataAnnotations;
using System.Data;
using Domain.Enums;

namespace Domain.Entities; 


public abstract class Base : Notifications
{   
    [Display(Name = "Codigo")]
    public Guid Id {get; protected set;} = Guid.NewGuid();

    [Display(Name = "Atualizado por")]
    public Guid UpdateBy {get; protected set;}

    [Display(Name = "Data/Hora de Atualização")]
    public DateTime UpdateDate {get; protected set;} = DateTime.UtcNow;
    


}