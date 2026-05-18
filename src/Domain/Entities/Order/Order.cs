using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

public enum Status
    {Pendente,  Enviado, Cancelado,}

public class Order : Base
{   
    [ForeignKey("Customer")]
    public Guid CustomerId {get; private set;}
    public Customer Customer {get; set;}
    public Guid ProductId {get; private set;}
    public int Quantity {get; private set;}
    public decimal Value {get; private set;}
    public DateTime OrderDate {get; private set;}
    public StatusOrder  Status {get; private set;}

    public Order (Guid customerId, Guid productId, int quantity, decimal value )
    {
       if(!ValidatePropertiesGuidId(customerId, "Customer id")) 
         return;
       if(!ValidatePropertiesGuidId(productId, "Product id"))
        return; 
       if(!ValidatePropertiesInt(quantity, "Quantity"))
        return; 
       if(!ValidatePropertiesDecimal(value, "Value"))
            return;
   

    this.CustomerId = customerId;   
    this.ProductId = productId;
    this.Quantity = quantity;
    this.Value = value; 

    this.OrderDate = DateTime.Now;
    this.Status = StatusOrder.Pending;

    }

    public void SetCustomer(Guid customerId)
    {
        CustomerId = customerId;
    }

    public void ConfirmeOrder(Product product)
    {
        product.DecreaseStock(Quantity);
    }

  





}