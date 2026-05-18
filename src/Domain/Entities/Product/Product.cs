using Domain.Entities;

public class Product : Base
{
    public Guid ProductId {get; private set;}
    public string NameProduct {get; private set;}
    public  decimal Price {get; private set;}
    public decimal Quantity {get; private set;}
    
    public Product (Guid productId, string nameProduct, decimal price, decimal quantity )
    {
        if(!ValidatePropertiesGuidId(productId , "Customer id")) 
        return;
       if(!ValidatePropertiesDecimal(price, "Value"))
        return;
       if(!ValidatePropertiesDecimal(quantity, "Value"))
        return;

        this.ProductId = productId;
        this.NameProduct = nameProduct;
        this.Price = price;
        this.Quantity = quantity;

    }
}