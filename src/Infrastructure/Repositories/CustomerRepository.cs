namespace Infrastructure.Repositories;

using Domain.Entities;

public class CustomerRepository : ICustomerRepository
{
    public Task AddAsync(Customer customer)
    {
        return Task.CompletedTask;
    }

    public Task<Customer?> GetByIdAsync(Guid id)
    {
        return Task.FromResult<Customer?>(null);
    }

    public Task UpdateAsync(Customer customer)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Customer customer)
    {
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}