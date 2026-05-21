namespace Domain.Entities;

public class GetOrder
{
    private readonly IOrderRepository _orderRepository;

    public GetOrder(IOrderRepository oderRepository)
    {
        _orderRepository = oderRepository;
    }

    public async Task<Order> Execute(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order == null)
            throw new Exception("Product not found");

        return order;
    }
}