using Application.Interfaces;
namespace Application.Customers

{
    public class DeleteCustomer
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomer(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Execute(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                throw new Exception("Customer not found");

            await _customerRepository.DeleteAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }
}