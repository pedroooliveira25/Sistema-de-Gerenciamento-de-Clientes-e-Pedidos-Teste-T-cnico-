using Domain.Entities;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByIdAsync(Guid id);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task SaveChangesAsync();
}