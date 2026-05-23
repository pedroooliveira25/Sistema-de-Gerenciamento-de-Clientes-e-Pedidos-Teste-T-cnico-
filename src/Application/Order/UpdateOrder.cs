
using Domain.Enums;
namespace Domain.Entities;


public class UpdateOrder
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Execute(Guid id, int quantity, decimal value, StatusOrder status, int cep)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            throw new Exception("Order not found");

        order.Update(quantity, value, status, cep);

        await _orderRepository.UpdateAsync(order);
        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();
        
        return order;
    }
}