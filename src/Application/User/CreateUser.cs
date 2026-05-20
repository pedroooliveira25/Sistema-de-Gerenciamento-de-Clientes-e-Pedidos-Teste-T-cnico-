
using Domain.Enums;
namespace Application.Users;

public class CreateUser
{   
    private readonly HashService _hashService;
    private readonly IUserRepository _repository;

    public CreateUser(IUserRepository repository)
    {
        _repository = repository;
        _hashService = hashService;
    }

    public async Task<User> Execute(string name, string email, string passwordHash, UserType userType)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name inválido");

        if (email.contains("@") || string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password inválido");

        if (!Enum.IsDefined(typeof(UserType), userType))
            throw new ArgumentException("UserType inválido");

        var user = new User(
            name,
            email,
            passwordHash,
            userType
        );

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return user;
    }
}