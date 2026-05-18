using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;


public class User : Base
{
    public string Password {get; private set;}
    public UserType UserType { get; private set;}

    public User(string name, string email, string password, UserType userType)
    {   
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "Password");

        this.id = Guid.NewGuid(); 
        this.Name = name; 
        this.Email =email;
        this.Password = password;

        this.UserType = userType; 
    }

    public void ValidateEmailUser()
    {
        
    }
} 