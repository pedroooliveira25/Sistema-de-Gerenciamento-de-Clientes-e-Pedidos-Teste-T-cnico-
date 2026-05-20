using System.Security.Cryptography;
using System.Text;

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
    
    [Column("Email")]
    public string Email {get; private set;}

    public User(string name, string email, string password, UserType userType, string address)
    {   
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "password");
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
        throw new Exception("Invalid email");

        if(!ValidatePropertiesString(name, "name"))
        throw new Exception("Invalid name");

        if(!ValidatePropertiesString(password, "Password"))
        throw new Exception("Invalid password"); 

        if(!ValidatePropertiesString(address, "Address"))
        throw new Exception("Invalid address"); 


        this.Address = address;
        this.NameUser = name; 
        this.Email =email;
        this.Password = password;
        this.UserType = userType; 
    }
   
} 