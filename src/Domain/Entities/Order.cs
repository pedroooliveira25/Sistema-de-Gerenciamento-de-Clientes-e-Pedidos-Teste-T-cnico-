using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

public class Order
{ 
        public enum Status
    {
        Pendente,
        Enviado,
        Cancelado,
    }

    public Guid id {get; private set;}
    public Guid ProductId {get; private set;}    
    public Guid ClientId {get; private set;}

    public DateTime OrderData {get; private set;} 
    public Status status {get; private set;} 


    public int Quantity {get; private set;}
    public decimal ValueProduct {get; private set;}

    public Order (Guid productId, Guid clientId, int quantity, decimal valueProduct)
    {
        if (ProductId == Guid.Empty)
            throw new Exception("Product inválido");
        if (clientId == Guid.Empty)
            throw new Exception("Client inválido");
        if (quantity <=0 )
            throw new Exception("Quantidade inválida");
        if (valueProduct <= 0)
            throw new Exception("Valor inválido");

    id = Guid.NewGuid();
    ProductId = productId;   
    ClientId = clientId;
    Quantity = quantity;
    ValueProduct = valueProduct; 

    OrderData = DateTime.Now;
    status = Status.Pendente;

    }

  





}