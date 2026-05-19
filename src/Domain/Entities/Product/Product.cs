using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;


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
    

   
    public Product (Guid productId, string nameProduct, decimal price, int quantity, int stock, StageProduct stageProduct)
    {
        if(!ValidatePropertiesString(nameProduct, "Name product"))
            throw new Exception("Nome do produto inválido");

        if(!ValidatePropertiesGuidId(productId , "Customer id")) 
        throw new Exception("Customer id inválido");

        if(!ValidatePropertiesDecimal(price, "Value"))
        throw new Exception("Preço inválido");

        if(!ValidatePropertiesInt(quantity, "Value"))
        throw new Exception("Quantidade inválida");

        if(!ValidatePropertiesInt(stock, "Value"))
        throw new Exception("Estoque inválido");

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
        AddNotification(StageProduct.OutOfStock.ToString(), "Quantidade deve ser maior que zero");
        return;
    }

    if (Stock < quantity)
    {
        AddNotification(StageProduct.InStock.ToString(), "Estoque insuficiente");
        return;
    }

    Stock -= quantity;
}

   public void Update(int quantity, decimal price, StageProduct stageProduct)
    {   
        if(!ValidatePropertiesDecimal(price, "Price"))
            throw new Exception("Preço inválido");
        if(!ValidatePropertiesInt(quantity, "Quantity"))
            throw new Exception("Quantidade inválida");
        if(!ValidatePropertiesInt(Stock, "Stock"))
            throw new Exception("Estoque inválido");
        if(stageProduct == StageProduct.OutOfStock)
            throw new Exception("Produto fora de estoque");

        this.Quantity = quantity;
        this.Price = price;
        this.StageProduct = stageProduct;
    }
}