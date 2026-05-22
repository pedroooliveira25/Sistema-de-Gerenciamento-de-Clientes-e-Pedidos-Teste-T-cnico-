
using Domain.Enums;
using Domain.Entities;


namespace Application.Customers;


public class UpdateCustomer
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomer(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Execute(Guid id, string name, string email, string password, string address, UserType userType, StageAccount stageAccount)
    {
        var customer = await _customerRepository.GetByIdAsync(id);

        if (customer == null)
            throw new Exception("Customer not found");

        customer.Update(name, email, password, address, userType, stageAccount);

        await _customerRepository.UpdateAsync(customer);
        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return customer;
    }
}