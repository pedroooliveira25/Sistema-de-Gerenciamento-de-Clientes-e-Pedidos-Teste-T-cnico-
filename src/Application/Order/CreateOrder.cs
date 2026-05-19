using Domain.Enums;

namespace Application.Orders;

public class CreateOrder
{
    private readonly IOrderRepository _repository;

    public CreateOrder(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> Execute(Guid customerId, Guid productId, int quantity, decimal value, DateTime orderDate, StatusOrder status)
    {
       if (quantity <= 0)
            throw new ArgumentException("Quantidade inválida");

        if (value <= 0)
            throw new ArgumentException("Valor inválido");

        var order = new Order(
            customerId,
            productId,
            quantity,
            value,
            DateTime.UtcNow,
            StatusOrder.Pending
        );
            

        await _repository.AddAsync(order);
        await _repository.SaveChangesAsync();

        return order;
    }
}