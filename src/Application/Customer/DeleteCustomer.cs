namespace Application.Customers
{
    public class DeleteCustomer
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
                throw new Exception("Customer não encontrado");

            await _repository.DeleteAsync(customer);
            await _repository.SaveChangesAsync();
        }
    }
}