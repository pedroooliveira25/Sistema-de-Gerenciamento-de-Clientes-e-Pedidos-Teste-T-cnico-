
using Domain.Entities;

namespace Application.Products;

public class DeleteProduct
{
    private readonly IProductRepository _productRepository;

    public DeleteProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Execute(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        await _productRepository .DeleteAsync(product);
        await _productRepository .SaveChangesAsync();
    }
}