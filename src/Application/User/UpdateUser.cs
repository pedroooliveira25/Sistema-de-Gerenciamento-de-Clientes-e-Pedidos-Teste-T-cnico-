using Domain.Entities;

namespace Application.UseCases.Users;

public class UpdateUser
{
    private readonly IUserRepository _repository;

    public UpdateUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Execute(Guid id, string name, string email)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User não encontrado");

        user.Update(name, email);

        await _repository.UpdateAsync(user);
        
        return user;
    }
}