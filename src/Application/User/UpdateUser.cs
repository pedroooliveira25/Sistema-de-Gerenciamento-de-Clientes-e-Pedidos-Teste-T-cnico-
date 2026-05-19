using Domain.Entities;

namespace Application.UseCases.Users;

public class UpdateUser
{
    private readonly IUserRepository _repository;

    public UpdateUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public User Execute(Guid id, string name, string email)
    {
        var user = _repository.GetById(id);

        if (user == null)
            throw new Exception("User não encontrado");

        user.Update(name, email);

        _repository.Update(user);
        
        return user;
    }
}