using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Entities;


[Table("Products")]
public class Product : Base


{

    [Column("Product_Id")]
    public Guid ProductId {get; private set;}

    [Column("Name_Product")]
    public string NameProduct {get; private set;}

    [Column("Price")]
    public  decimal Price {get; private set;}

    [Column("Quantity")]
    public int Quantity {get; private set;}

    [Column("Stock")]
    public int Stock {get; private set;}

    [Column("Stage_Product")]
    public StageProduct StageProduct {get; private set;}

    public List<Order> Orders { get; set; } = new();
    

    public Product(){}
    public Product (Guid productId, string nameProduct, decimal price, int quantity, int stock, StageProduct stageProduct)
    {
        if(!ValidatePropertiesString(nameProduct, "Name product"))
            throw new Exception("Invalid product name");

        if(!ValidatePropertiesGuidId(productId , "Customer id")) 
        throw new Exception("Invalid customer ID");

        if(!ValidatePropertiesDecimal(price, "Value"))
        throw new Exception("Invalid price");

        if(!ValidatePropertiesInt(quantity, "Value"))
        throw new Exception("Invalid quantity");

        if(!ValidatePropertiesInt(stock, "Value"))
        throw new Exception("Invalid stock");

        this.ProductId = productId;
        this.NameProduct = nameProduct;
        this.Price = price;
        this.Quantity = quantity;
        this.Stock = stock;
        this.StageProduct = stageProduct;
    }

    public void DecreaseStock(int quantity)
{
    if (quantity <= 0)
    {
        AddNotification(StageProduct.OutOfStock.ToString(), "Quantity must be greater than zero");
        return;
    }

    if (Stock < quantity)
    {
        AddNotification(StageProduct.InStock.ToString(), "Insufficient stock");
        return;
    }

    Stock -= quantity;
}

   public void Update(string nameProduct, int quantity, decimal price, StageProduct stageProduct)
    {   
        if(!ValidatePropertiesDecimal(price, "Price"))
            throw new Exception("Invalid price");
        if(!ValidatePropertiesInt(quantity, "Quantity"))
            throw new Exception("Invalid quantity");
        if(!ValidatePropertiesInt(Stock, "Stock"))
            throw new Exception("Invalid stock");
        if(stageProduct == StageProduct.OutOfStock)
            throw new Exception("Product out of stock");

        this.Quantity = quantity;
        this.Price = price;
        this.StageProduct = stageProduct;
        this.NameProduct = nameProduct;
    }
}