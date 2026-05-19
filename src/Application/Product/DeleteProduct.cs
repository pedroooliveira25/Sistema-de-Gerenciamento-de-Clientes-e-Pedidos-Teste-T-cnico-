namespace Application.Products;

public class DeleteProduct
{
    private readonly IProductRepository _repository;

    public DeleteProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(Guid id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product não encontrado");

        await _repository.DeleteAsync(product);
        await _repository.SaveChangesAsync();
    }
}