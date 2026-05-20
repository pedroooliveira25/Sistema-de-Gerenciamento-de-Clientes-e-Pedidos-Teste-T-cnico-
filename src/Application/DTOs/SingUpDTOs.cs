public class CreatRequestSingUp 
{

    [Required]
    [MinLength(3)]
    public string NameUser {get; set;}
     [Required]
     [EmailAddress]
     public string Email {get; set;}
     [Required]
     public string Address {get; set;}
     [Required]
     [MinLength(6)]
     public string Password {get; set;}

}