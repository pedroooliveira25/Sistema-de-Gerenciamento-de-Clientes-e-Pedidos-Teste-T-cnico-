namespace Application.Interfaces;
public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
    Task SaveChangesAsync();
}