
namespace Application.Interfaces;

public class GetUser
{
    private readonly IUserRepository _userRepository;

    public GetUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Execute(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User não encontrado");

        return user;
    }
}