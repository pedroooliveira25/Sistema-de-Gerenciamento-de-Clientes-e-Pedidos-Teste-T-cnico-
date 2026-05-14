    public enum Status
    {Pendente,  Enviado, Cancelado,}

public class Order
{ 
    
    public Guid id {get; private set;}
    public Guid ProductId {get; private set;}    
    public Guid ClientId {get; private set;}

    public DateTime OrderData {get; private set;} 
    public Status status {get; private set;} 


    public int Quantity {get; private set;}
    public decimal ValueProduct {get; private set;}

    public Order (Guid productId, Guid clientId, int quantity, decimal valueProduct)
    {
        if (productId == Guid.Empty)
            throw new Exception("Product inválido");
        if (clientId == Guid.Empty)
            throw new Exception("Client inválido");
        if (quantity <=0 )
            throw new Exception("Quantidade inválida");
        if (valueProduct <=0)
            throw new Exception("Valor inválido");

    this.id = Guid.NewGuid();
    this.ProductId = productId;   
    this.ClientId = clientId;
    this.Quantity = quantity;
    this.ValueProduct = valueProduct; 

    this.OrderData = DateTime.Now;
    this.status = Status.Pendente;

    }

  





}