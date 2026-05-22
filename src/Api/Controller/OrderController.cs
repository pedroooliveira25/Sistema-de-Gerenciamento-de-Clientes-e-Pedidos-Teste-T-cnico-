
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Domain.Entities;
using System.Security.Claims;
using Domain.Enums;
namespace Api.Controller;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private  readonly CreateOrder _createOrder; 
    public OrderController (CreateOrder createOrder)
    {
        _createOrder = createOrder; 
    }

    [Authorize(Roles = "CLIENT")]
    [HttpPost("create")]

    public async Task<IActionResult> Create([FromBody] CreateOrderDTO request){
        if (request == null)
            return BadRequest("Order is invalid"); 

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 

        if(userId == null)
            return Unauthorized(); 

        var order = await _createOrder.Execute(
            Guid.Parse(userId),
            request.ProductId,
            request.Quantity,
            request.Value,
            DateTime.UtcNow,
            StatusOrder.Pending,
            request.Address
        );
        
            
         return Ok(order);
    }
}