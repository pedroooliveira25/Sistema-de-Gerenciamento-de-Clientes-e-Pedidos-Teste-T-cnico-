public class DeleteUser
{
    private readonly IUserRepository _repository;

    public DeleteUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public async  Task Execute(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);

         if (user == null)
            throw new Exception("User não encontrado");

        await _repository.DeleteAsync(user);
        await _repository.SaveChangesAsync();
    }
}