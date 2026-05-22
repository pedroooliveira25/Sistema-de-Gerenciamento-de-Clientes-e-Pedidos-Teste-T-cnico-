namespace Infrastructure.Repositories;
using Domain.Entities;

public class ProductRepository : IProductRepository
{
    public Task AddAsync(Product product)
    {
        return Task.CompletedTask;
    }

    public Task CreateProductAsync(Product product)
    {
        return Task.CompletedTask;
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return Task.FromResult<Product?>(null);
    }

    public Task UpdateAsync(Product product)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Product product)
    {
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}