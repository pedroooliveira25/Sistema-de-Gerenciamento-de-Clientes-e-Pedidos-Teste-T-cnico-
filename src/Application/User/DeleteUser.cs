public class DeleteUser
{
    private readonly IUserRepository _repository;

    public DeleteUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {
        var user = _repository.GetById(id);

         if (user == null)
            throw new Exception("User não encontrado");

        _repository.Delete(user);
        _repository.SaveChanges();
    }
}