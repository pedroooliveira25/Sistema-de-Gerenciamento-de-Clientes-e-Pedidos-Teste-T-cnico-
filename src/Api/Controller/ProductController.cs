
using Microsoft.AspNetCore.Mvc;
using Application.Products;
using Domain.Entities;



[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly CreateProduct _createProduct; 
    private readonly UpdateProduct _updateProduct;

    //injeção de dependencia
    public ProductController(IProductRepository productRepository, CreateProduct createProduct, UpdateProduct updateProduct)
    {
        _createProduct = createProduct;
        _productRepository = productRepository; 
        _updateProduct = updateProduct;

    }

    //retorno esperado 200ok 
    [HttpPost("createProduct")]

    //criando uma funcao assincrona e que retorne metodos HTTPS quando chamar meu objeto 
    //porem acredito q posso estar errado de fazer essa logica do ADM aqui no controller

    public async Task<IActionResult> CreateProduct (CreatProductRequestDTOs request)
    {
        if (request == null)
        return BadRequest("Product is invalid");

    if (!User.IsInRole("ADM"))
        return Forbid();

    var create = await _createProduct.Execute(
    request.NameProduct,
    request.ProductId,
    request.Price,
    request.Stock,
    request.Quantity,
    request.StageProduct
    );
   
        return Ok(create);
    }

    [HttpPut("UpdateProducts")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTOs request)
    {
        if (request == null)
        return BadRequest("Product is invalid");

        if (!User.IsInRole("ADM"))
        //é pra retornar 403
        return Forbid();

        var uptadeResult = await _updateProduct.Execute(request);

        return Ok(uptadeResult);
    }
        
}
