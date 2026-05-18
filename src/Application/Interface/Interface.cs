using Domain.Entities;

public interface ICustomerRepository
{
    void Add(Customer customer);
    void SaveChanges();
}