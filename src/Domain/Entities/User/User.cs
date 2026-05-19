using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;

public class User : Base
{   
    [Column("Name_User")]
    public string NameUser {get; private set;}
    
    [Column("Password")]
    public string Password {get; private set;}
    [Column("UserType")]
    public UserType UserType { get; private set;}

    [Column("Address")]
    public string Address {get; private set;}

    public User(string name, string email, string password, UserType userType, string address)
    {   
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "Password");
        ValidatePropertiesString(address, "Address");

        this.Id = Guid.NewGuid(); 
        this.Address = address;
        this.NameUser = name; 
        this.Email =email;
        this.Password = password;

        this.UserType = userType; 
    }

    public List<User>Users {get; set;} = new List<User>();

    public void Update(string name, string email, string password, UserType userType, string address )
    {
        if(!ValidatePropertiesString(email, "email"))
        throw new Exception("Email inválido");

        if(!ValidatePropertiesString(name, "name"))
        throw new Exception("Nome inválido");

        if(!ValidatePropertiesString(password, "Password"))
        throw new Exception("Password inválida"); 

        if(!ValidatePropertiesString(address, "Address"))
        throw new Exception("Address inválida"); 


        this.Address = address;
        this.NameUser = name; 
        this.Email =email;
        this.Password = password;
        this.UserType = userType; 
    }
   
} 