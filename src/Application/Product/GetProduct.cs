namespace Application.Products;

public class GetProduct
{
    private readonly IProductRepository _repository;

    public GetProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Execute(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product não encontrado");

        return product;
    }
}