using Domain.Entities;

public class Product : Base
{
    public Guid ProductId {get; private set;}
    public string NameProduct {get; private set;}
    public  decimal Price {get; private set;}
    public int Quantity {get; private set;}

    public int Stock {get; private set;}
    
    public Product (Guid productId, string nameProduct, decimal price, int quantity, int stock )
    {
        if(!ValidatePropertiesGuidId(productId , "Customer id")) 
        return;
        if(!ValidatePropertiesDecimal(price, "Value"))
        return;
        if(!ValidatePropertiesInt(quantity, "Value"))
        return;
        if(!ValidatePropertiesInt(Stock, "Value"))
        return;

        this.ProductId = productId;
        this.NameProduct = nameProduct;
        this.Price = price;
        this.Quantity = quantity;
        this.Stock = stock;
    }

    public void DecreaseStock(int quantity)
{
    if (quantity <= 0)
    {
        AddNotification("Stock", "Quantidade inválida");
        return;
    }

    if (Stock < quantity)
    {
        AddNotification("Stock", "Estoque insuficiente");
        return;
    }

    Stock -= quantity;
}


}