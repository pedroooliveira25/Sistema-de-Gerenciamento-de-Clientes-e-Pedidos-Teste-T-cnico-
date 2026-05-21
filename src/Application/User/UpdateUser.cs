
using Domain.Enums;

namespace Application.Interfaces;

public class UpdateUser
{
    private readonly IUserRepository _productRepository;

    public UpdateUser(IUserRepository userRepository)
    {
        _productRepository = userRepository;
    }

    public async Task<User> Execute(Guid id, string name, string email, string password, string address, UserType userType)
    {
        var user = await _productRepository.GetByIdAsync(id);

        if (user == null)
            throw new Exception("User não encontrado");

        user.Update( email, name, password, userType,  address);

        await _productRepository.UpdateAsync(user);
        await _productRepository.AddAsync(user);
        await _productRepository.SaveChangesAsync();

        return user;
    }
}