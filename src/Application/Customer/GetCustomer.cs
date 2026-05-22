using Application.Interfaces;
namespace Application.Customers;

public class GetCustomer
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomer(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Execute(Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
            throw new Exception("Customer not found");

        return customer;
    }
}