using Domain.Enums;

namespace Domain.Entities;


public class CreateOrder
{   
    private readonly IProductRepository _productRepository; 
    private readonly IOrderRepository _orderRepository;

    private readonly IUserRepository _userRepository; 
    
    public CreateOrder(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
    {   
        _userRepository = userRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public async Task<Order> Execute( Guid customerId, Guid productId, int quantity, decimal value, DateTime orderDate, StatusOrder status, string address)
    {
        //OBS: sei q ta cheio de If aqui poderia usar outros metodos, mas essa é a v1, quero ver se funciona. 
        var user = await _userRepository.GetByIdAsync(customerId);

        if (user == null)
            throw new Exception("User not found");

        if (user.UserType != UserType.CLIENTE)
            throw new Exception("Only clients can create orders");
        
        var product = await _productRepository.GetByIdAsync(productId);
        //acho q ja fiz essa regra antes, pode ser q n de certo. 
        if (product == null)
            throw new Exception("Product not found");


        if (product.Stock < quantity)
            throw new Exception("Insufficient stock");

        if (quantity <= 0)
            throw new ArgumentException("Quantity is invalid");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address is invalid");

        if (value <= 0)
            throw new ArgumentException("Value is invalid");
       
            //Sei q pode existir outras regras aqui, mas infelizmente n tenho ideia do que colocar por agora
        var order = new Order(
            customerId,
            productId,
            quantity,
            value,
            DateTime.UtcNow,
            StatusOrder.Pending,
            address
        );
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return order;
    }
}