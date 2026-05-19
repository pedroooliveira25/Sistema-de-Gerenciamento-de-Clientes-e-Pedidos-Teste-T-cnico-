
using Domain.Enums;
namespace Application.Orders;

public class UpdateOrder
{
    private readonly IOrderRepository _repository;

    public UpdateOrder(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> Execute(Guid id, int quantity, decimal value, StatusOrder status)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            throw new Exception("Order não encontrado");

        order.Update(quantity, value, status);

        await _repository.UpdateAsync(order);
        await _repository.SaveChangesAsync();
        
        return order;
    }
}