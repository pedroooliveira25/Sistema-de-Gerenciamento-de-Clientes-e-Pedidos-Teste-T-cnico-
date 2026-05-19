namespace Application.Users;

public class GetUser
{
    private readonly IUserRepository _repository;

    public GetUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Execute(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User não encontrado");

        return user;
    }
}