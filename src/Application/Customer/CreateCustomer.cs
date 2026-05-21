
using Domain.Enums;
namespace Application.Customers;

public class CreateCustomer
{
    private readonly ICustomerRepository _repository;

    public CreateCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Execute(string name, string email, string password, string address, UserType userType, StageAccount stageAccount)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name inválido");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password inválido");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address inválido");

        if (!Enum.IsDefined(typeof(UserType), userType))
            throw new ArgumentException("UserType inválido");

        if (!Enum.IsDefined(typeof(StageAccount), stageAccount))
            throw new ArgumentException("StageAccount inválido");

        var customer = new Customer(
            name,
            email,
            Guid.NewGuid(),
            password,
            address,
            userType,
            stageAccount
        );

        await _repository.AddAsync(customer);

        return customer;
    }
}