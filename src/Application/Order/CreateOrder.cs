using Domain.Enums;
namespace Domain.Entities;


public class CreateOrder
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Execute(Guid customerId, Guid productId, int quantity, decimal value, DateTime orderDate, StatusOrder status)
    {
       if (quantity <= 0)
            throw new ArgumentException("Quantity is invalid");

        if (value <= 0)
            throw new ArgumentException("Value is invalid");

        var order = new Order(
            customerId,
            productId,
            quantity,
            value,
            DateTime.UtcNow,
            StatusOrder.Pending
        );
            

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return order;
    }
}