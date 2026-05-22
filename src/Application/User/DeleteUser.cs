using Domain.Entities;

namespace Application.Interfaces.Users;


public class DeleteUser

{
    private readonly IUserRepository _userRepository;

    public DeleteUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Execute(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User not found");

        await _userRepository.DeleteAsync(user);
        await _userRepository.SaveChangesAsync();
    }
}