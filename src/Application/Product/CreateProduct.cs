
using Domain.Enums;
namespace Application.UseCases.Products;
public class CreateProduct
{
    private readonly IUserRepository _repository;

    public CreateProduct(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Execute(string name, string email, string password, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name inválido");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password inválido");
        
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password inválido");

        var product = new User(
            name,
            email,
            password
        );

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return product;
    }
}