
using Domain.Enums;
namespace Application.Customers;

public class UpdateCustomer
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomer(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Execute(Guid id, string name, string email, string password, string address, UserType userType, StageAccount stageAccount)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            throw new Exception("Customer não encontrado");

        customer.Update(name, email, password, address, userType, stageAccount);

        await _repository.UpdateAsync(customer);
        await _repository.SaveChangesAsync();

        return customer;
    }
}