
namespace Application.Products;
using Domain.Enums;
public class UpdateProduct
{
    private readonly IProductRepository _productRepository;

    public UpdateProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Execute(Guid id, string nameProduct, decimal price, int quantity, int stock, StageProduct stageProduct)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found");

        product.Update(quantity, price, stageProduct); 

        await _productRepository.UpdateAsync(product);
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        
        return product;
    }
}