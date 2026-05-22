
namespace Application.Products;
public class UpdateProduct
{
    private readonly IProductRepository _productRepository;

    public UpdateProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Execute( UpdateProductDTOs request)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (request == null)
            throw new Exception ("Product is invalid");

        product.Update(
            request.NameProduct,
            request.Quantity,
            request.Price,
            request.StageProduct
        );

        await _productRepository.UpdateAsync(product);
        return product;
    }

}