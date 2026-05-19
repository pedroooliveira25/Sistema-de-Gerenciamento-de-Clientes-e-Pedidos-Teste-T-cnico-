using Domain.Entities;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task SaveChangesAsync();
}