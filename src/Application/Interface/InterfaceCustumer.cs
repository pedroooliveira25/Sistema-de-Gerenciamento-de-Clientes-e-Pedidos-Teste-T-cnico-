
public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);
    void UpdateAsync(Customer customer);
    void DeleteAsync(Customer customer);
  
}