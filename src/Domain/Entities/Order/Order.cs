using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;

namespace Domain.Enums;

public class Order : Base
{
    [ForeignKey("Customer")]
    public Guid CustomerId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Value { get; private set; }
    public DateTime OrderDate { get; private set; }
    public StatusOrder Status { get; private set; }



    public Order(Guid customerId, Guid productId, int quantity, decimal value, DateTime orderDate, StatusOrder status)
    {
        if (!ValidatePropertiesGuidId(customerId, "Customer id"))
        {
            throw new ArgumentException("Customer id inválido");
        }

        if (!ValidatePropertiesGuidId(productId, "Product id"))
        {
            throw new ArgumentException("Product id inválido");
        }

        if (!ValidatePropertiesInt(quantity, "Quantity"))
        {
            throw new ArgumentException("Quantity inválida");
        }

        if (!ValidatePropertiesDecimal(value, "Value"))
        {
            throw new ArgumentException("Value inválida");
        }


        this.CustomerId = customerId;
        this.ProductId = productId;
        this.Quantity = quantity;
        this.Value = value;

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
        Quantity = quantity;
        Value = value;
        Status = status;
    }
}