using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;


[Table("Customer")]
public class Customer : Base
{
    public string Name { get; private set;}
    public string Email { get; private set;}
    public string Password {get; private set;}
    public StageAccount StageAccount { get; private set; }
    public string Address {get; private set;}
    public UserType UserType { get; private set;}
    public StageAccount Stage{get; private set;}
    public Guid UserId {get; private set;}
    public List<Order> Orders {get; private set;} = new();


    public Customer(string name, string email, Guid userId, string password, string address, UserType userType, StageAccount stageAccount)
    {
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "password");
        ValidatePropertiesGuidId(userId, "id");

        this.UserId = userId; 
        this.Address = address;
        this.Name = name; 
        this.Email =email;
        this.Password = password;

        this.StageAccount = StageAccount.Active;
        this.UserType = userType; 
        
    }


    public void AddOrder(Order order)
    {
        if (StageAccount == StageAccount.Blocked)
        {
            AddNotification("Order", "Blocked customer cannot add orders");
                return;  
        }

    order.SetCustomer (this.Id);
    Orders.Add(order); 
    }

    
    public void ChangeEmail(string newEmail)
    {
        Email = newEmail; 
    }

      public void ChangePassword(string newPassword)
    {
        Password = newPassword; 
    }

    public void ChangeAddress(string newAddress)
    {
        Address = newAddress; 
    }

    public void ChangeStage(StageAccount newStage)
    {
        if(StageAccount == StageAccount.Blocked && newStage == StageAccount.Active)
        {
           return;

        }
        this.StageAccount = newStage;
    }
     public void Update(string name, string email, string password, string address, UserType userType, StageAccount stageAccount)
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;
        UserType = userType;
        StageAccount = stageAccount;
    }
}
                                            