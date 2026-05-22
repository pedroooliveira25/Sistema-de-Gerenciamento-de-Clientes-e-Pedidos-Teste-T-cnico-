using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

[Table("Oders")]
public class Order : Base
{

    [Column("Quantity")]
    public int Quantity { get; private set; }
    [Column("Value")]
    public decimal Value { get; private set; }
    [Column("OrderDate")]
    public DateTime OrderDate { get; private set; }
    [Column("Status")]
    public StatusOrder Status { get; private set; }
    [Column("Address")]
    public string Address { get; private set; }

    [Column("Customer_Id")]
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    [Column("Product_Id")]
    public Guid ProductId { get; private set; }   
    public Product? Product { get; private set; }

    public Order(){}
    public Order(Guid customerId, Guid productId, int quantity, decimal value, DateTime orderDate, StatusOrder status, string address)
    {
        if (!ValidatePropertiesGuidId(customerId, "Customer id"))
        {
            throw new ArgumentException("Invalid customer ID");
        }

        if (!ValidatePropertiesGuidId(productId, "Product id"))
        {
            throw new ArgumentException("Invalid product ID");
        }

        if (!ValidatePropertiesInt(quantity, "Quantity"))
        {
            throw new ArgumentException("Invalid quantity");
        }

        if (!ValidatePropertiesDecimal(value, "Value"))
        {
            throw new ArgumentException("Invalid value");
        }
        if (!ValidatePropertiesString(address, "Address"))
        {
            throw new ArgumentException("Invalid address");
        }


        this.CustomerId = customerId;
        this.ProductId = productId;
        this.Quantity = quantity;
        this.Value = value;
        this.Address = address;

        this.OrderDate = orderDate;
        this.Status = status;

    }

    public void SetCustomer(Guid customerId)
    {
        CustomerId = customerId;
    }

    public void ConfirmeOrder(Product product)
    {
        product.DecreaseStock(Quantity);
    }

    public void Update(int quantity, decimal value, StatusOrder status)
    {
        if (!ValidatePropertiesInt(quantity, "Quantity"))
            throw new ArgumentException("Invalid quantity");

        if (!ValidatePropertiesDecimal(value, "Value"))            
            throw new ArgumentException("Invalid value");

        if (!ValidatePropertiesGuidId(Id, "Order id"))
            throw new ArgumentException("Invalid order ID");
        if (status == StatusOrder.Sending)
        {
            throw new InvalidOperationException("It is not possible to update a confirmed order.");
        }

        this.Quantity = quantity;
        this.Value = value;
        this.Status = status;
    }
}