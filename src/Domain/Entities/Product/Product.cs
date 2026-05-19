using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities;
using Domain.Enums;


[Table("Products")]
public class Product : Base

//personalizando ja minha tabela, para não ficar com o nome da classe.
{
    private string address;

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
    public StageProduct stageProduct {get; private set;}
    

   
    public Product (Guid productId, string nameProduct, decimal price, int quantity, int stock, StageProduct stageProduct)
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
        this.stageProduct = stageProduct;
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

    public void Update(string name, string email)
    {
        throw new NotImplementedException();
    }
}