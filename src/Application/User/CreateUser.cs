
using Domain.Enums;
namespace Application.UseCases.Customers;
public class CreateUser
{
    private readonly ICustomerRepository _repository;

    public CreateUser(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Customer Execute(string name, string email, string password, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name inválido");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password inválido");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address inválido");

        var customer = new Customer(
            name,
            email,
            password,
            address,
            StageAccount.Active
        );

        _repository.Add(customer);
        _repository.SaveChanges();

        return customer;
    }
}