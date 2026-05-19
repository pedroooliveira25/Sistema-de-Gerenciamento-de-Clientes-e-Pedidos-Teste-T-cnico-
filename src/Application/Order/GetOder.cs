using Domain.Enums;

namespace Application.Orders;

public class GetOrder
{
    private readonly IOrderRepository _repository;

    public GetOrder(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Order> Execute(Guid id)
    {
        var order = await _repository.GetByIdAsync(id);

        if (order == null)
            throw new Exception("Order não encontrado");

        return order;
    }
}