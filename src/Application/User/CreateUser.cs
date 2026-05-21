
using Domain.Enums;
using Infrastructure;
namespace Application.Interfaces;

public class CreateUser
{   
    private readonly HashService _hashService;
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;



    public CreateUser(IUserRepository userRepository, ICustomerRepository customerRepository, HashService hashService)
    {
       _userRepository = userRepository;
       _customerRepository = customerRepository;
       _hashService = hashService;
    }

    public async Task<User> Execute(string name, string email, string password, UserType userType, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name inválido");

        if (!email.Contains("@") || string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password inválido");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address inválido");

        if (!Enum.IsDefined(typeof(UserType), userType))
            throw new ArgumentException("UserType inválido");

        var passwordHash = _hashService.GenerateSha256(password);

        var user = new User(
            name,
            email,
            password,
            userType,
            address
        );

        await _userRepository.AddAsync(user);

        var customer = new Customer(
            name,
            email,
            user.Id,
            password,
            address,
            userType,
            StageAccount.Active
        );
        
        await _customerRepository.AddAsync(customer);

        return user;
    }


}