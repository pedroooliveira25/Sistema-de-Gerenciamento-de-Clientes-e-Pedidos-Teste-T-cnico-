public class DeleteUser
{
    private readonly ICustomerRepository _repository;

    public DeleteUser(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {
        var customer = _repository.GetById(id);

         if (customer == null)
            throw new Exception("Customer não encontrado");

        _repository.Delete(customer);
        _repository.SaveChanges();
    }
}