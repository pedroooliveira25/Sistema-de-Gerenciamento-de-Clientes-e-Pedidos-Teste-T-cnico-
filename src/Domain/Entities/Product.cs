using System.ComponentModel;

public class Product
{
    private Guid productId;
    private string name; 
    private decimal priceProduct; 
    private int stock; 
    private string category;

    public Product(Guid productId, string name, decimal priceProduct, int stock, string category)
    {
        if (string.IsNullOrEmpty(name))
            throw new Exception ("Name inválido");
        if (priceProduct < 0 )
            throw new Exception("preço invalido");
        if (stock < 0) 
            throw new Exception("Estoque invalido");
        if (category == null)
            throw new Exception("Categoria inválida");

        this.productId = Guid.NewGuid();
        this.name = name;
        this.priceProduct = priceProduct;
        this.category = category;


    }
}


