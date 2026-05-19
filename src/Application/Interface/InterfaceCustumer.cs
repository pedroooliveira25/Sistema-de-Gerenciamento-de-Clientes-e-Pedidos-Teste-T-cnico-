using Domain.Entities;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Customer GetById(Guid id);

    void Delete(Customer customer);
    void SaveChanges();
}