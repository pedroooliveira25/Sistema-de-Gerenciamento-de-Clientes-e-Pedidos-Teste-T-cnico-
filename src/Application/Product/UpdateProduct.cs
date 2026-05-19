using Domain.Entities;

namespace Application.UseCases.Products;

public class UpdateProduct
{
    private readonly IProductRepository _repository;

    public UpdateProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Execute(Guid id, string name, string email)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product não encontrado");

        product.Update(name, email);

        await _repository.UpdateAsync(product);
        
        return product;
    }
}