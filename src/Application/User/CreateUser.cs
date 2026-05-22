
using Domain.Enums;
using Domain.Entities;
using Application.Interfaces;

namespace Application;


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
            throw new ArgumentException("Name is invalid");

        if (!email.Contains("@") || string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is invalid");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is invalid");

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address is invalid");

        if (!Enum.IsDefined(typeof(UserType), userType))
            throw new ArgumentException("UserType is invalid");

        var passwordHash = _hashService.GenerateSha256(password);
    
        var user = new User(
            name,
            email,
            passwordHash,
            userType,
            address
        );

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var customer = new Customer(
            name,
            email,
            user.Id,
            passwordHash,
            address,
            userType,
            StageAccount.Active
        );
        
        await _customerRepository.AddAsync(customer);
        await _userRepository.SaveChangesAsync();

        return user;
    }


}