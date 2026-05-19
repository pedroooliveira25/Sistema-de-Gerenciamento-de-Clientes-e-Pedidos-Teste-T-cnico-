
using Domain.Enums;
namespace Application.UseCases.Products;
public class CreateProduct
{
    private readonly IProductRepository _repository;

    public CreateProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Execute(string nameProduct, Guid productId, decimal price, int stock, int quantity, StageProduct stageProduct)
    {

        if (string.IsNullOrWhiteSpace(nameProduct))
            throw new ArgumentException("Name inválido");

        if (price <= 0)
            throw new ArgumentException("Preço inválido");

        if (stock < 0)
            throw new ArgumentException("Estoque inválido");

        var product = new Product(
            productId,
            nameProduct,
            price,
            quantity,
            stock,
            stageProduct
        );

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        return product;
    }

    
}