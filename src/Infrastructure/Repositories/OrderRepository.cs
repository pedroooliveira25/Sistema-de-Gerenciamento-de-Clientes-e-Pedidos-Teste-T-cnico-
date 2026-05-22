namespace Infrastructure.Repositories;
using Domain.Entities;

public class OrderRepository : IOrderRepository
{
    public Task AddAsync(Order order)
    {
        return Task.CompletedTask;
    }

    public Task CreateProductAsync(Order order)
    {
        return Task.CompletedTask;
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        return Task.FromResult<Order?>(null);
    }

    public Task UpdateAsync(Order order)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Order order)
    {
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}