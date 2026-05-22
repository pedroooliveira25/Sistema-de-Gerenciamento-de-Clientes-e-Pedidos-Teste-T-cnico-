
using Domain.Enums;
using Application.Interfaces;
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
            throw new ArgumentException("Name is invalid");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is invalid");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is invalid");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address is invalid");

        if (!Enum.IsDefined(typeof(UserType), userType))
            throw new ArgumentException("UserType is invalid");

        if (!Enum.IsDefined(typeof(StageAccount), stageAccount))
            throw new ArgumentException("StageAccount is invalid");

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