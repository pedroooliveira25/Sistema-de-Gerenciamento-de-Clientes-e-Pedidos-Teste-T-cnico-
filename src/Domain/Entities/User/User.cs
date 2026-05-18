using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;


public class User : Base
{
    public string Email {get; private set;}
    public string Password {get; private set;}
      
    public User(string name, string email, string password)
    {   
        ValidatePropertiesString(Email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(Password, "Password");
        ValidatePropertiesGuidId(id, "id" );


        this.id = Guid.NewGuid(); 
        this.Name = name; 
        this.Email =email;
        this.Password = password; 
    }

} 