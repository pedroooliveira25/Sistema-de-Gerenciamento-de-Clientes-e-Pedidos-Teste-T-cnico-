
public interface IProductRepository
{
    Task CreateProductAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    void UpdateAsync(Product product);
    void DeleteAsync(Product product);
    
}