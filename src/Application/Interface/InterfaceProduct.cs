
public interface IProductRepository
{
    Task CreateProductAsync(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
    Task SaveChangesAsync();
}