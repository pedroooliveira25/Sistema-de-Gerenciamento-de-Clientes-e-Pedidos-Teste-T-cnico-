
using Domain.Enums;
namespace Application.Products;
public class CreateProduct
{
    private readonly IProductRepository _productRepository;

    public CreateProduct(IProductRepository productRepository)
    {
       _productRepository = productRepository;
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

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return product;
    }

    
}