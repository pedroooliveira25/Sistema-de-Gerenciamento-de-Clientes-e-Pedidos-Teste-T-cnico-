using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;


public class User : Base
{
    public string Password {get; private set;}
    public UserType UserType { get; private set;}

    public string Address {get; private set;}

    public User(string name, string email, string password, UserType userType, string address)
    {   
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "Password");
        ValidatePropertiesString(address, "Address");

        this.Id = Guid.NewGuid(); 
        this.Address = address;
        this.Name = name; 
        this.Email =email;
        this.Password = password;

        this.UserType = userType; 
    }

    public List<User>Users {get; set;} = new List<User>(); 
    
} 