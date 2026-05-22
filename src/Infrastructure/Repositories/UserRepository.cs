namespace Infrastructure.Repositories;
using Domain.Entities;

public class UserRepository : IUserRepository
{
    public Task AddAsync(User user)
    {
        return Task.CompletedTask;
    }

     public Task<User?> GetByIdAsync(Guid id)
    {
        return Task.FromResult<User?>(null);
    }
    public Task<User?> GetByEmailAsync(string email)
{
    return Task.FromResult<User?>(null);
}

    public Task UpdateAsync(User user)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(User user)
    {
        return Task.CompletedTask;
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}