using Domain.Entities;

namespace Application.UseCases.Customers;

public class GetUser
{
    private readonly ICustomerRepository _repository;

    public GetUser(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public Customer Execute(Guid id)
    {
        var customer = _repository.GetById(id);

        if (customer == null)
            throw new Exception("Customer não encontrado");

        return customer;
    }
}