namespace Application.Dtos;
using System.ComponentModel.DataAnnotations;
using Domain.Enums;

public class SignupRequest 
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

     public UserType UserType {get; set;}

}