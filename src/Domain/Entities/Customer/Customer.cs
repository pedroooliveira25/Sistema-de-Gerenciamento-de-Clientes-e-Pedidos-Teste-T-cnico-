using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;


[Table("Customer")]
public class Customer : Base
{
    public string Password {get; private set;}
    public string Address {get; private set;}
    public UserType UserType { get; private set;}
    public StageAccount Stage{get; private set;}
    public List<Order> Orders {get; private set;}

    public Guid CustomerID {get; private set;}
    public Customer customer {get; set;}
    
   public Customer (string name, string email, Guid id, string password, string address, StageAccount stage)
    {
        ValidatePropertiesString(email, "email");
        ValidatePropertiesString(name, "name");
        ValidatePropertiesString(password, "password");
        ValidatePropertiesGuidId(id, "id");

        this.Id = Guid.NewGuid(); 
        this.Address = address;
        this.Name = name; 
        this.Email =email;
        this.Password = password;

        this.Stage = stage;
        this.UserType = UserType.CLIENTE; 
        Orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        if (Status == StageAccount.Blocked)
        {
            AddNotification("Order", "Cliente bloqueado não pode adicionar pedido");
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
        if(Stage == StageAccount.Blocked && newStage == StageAccount.Ative)
        {
           return;

        }
        this.Stage = newStage;
    }
}
                                            