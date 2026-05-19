using Domain.Enums;

namespace Application.Customers;

public class GetCustomer
{
    private readonly ICustomerRepository _repository;

    public GetCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Execute(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            throw new Exception("Customer não encontrado");

        return customer;
    }
}