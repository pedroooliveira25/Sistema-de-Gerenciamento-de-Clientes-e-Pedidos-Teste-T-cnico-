using System.ComponentModel.DataAnnotations;
namespace Application.Dtos;

public class LoginRequest
{   
     [Required]
     public string Password {get; set;}
     [Required]
     public string Email {get; set;}

    
}