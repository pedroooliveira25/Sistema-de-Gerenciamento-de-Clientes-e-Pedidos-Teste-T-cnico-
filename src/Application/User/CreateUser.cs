using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

using Domain.Entities;
public class CreateUser 
{
 public User Execute(string email, string name, string password, UserType userType)
{
    var user = new User(email, name, password, userType);
    return user;
}
    
}