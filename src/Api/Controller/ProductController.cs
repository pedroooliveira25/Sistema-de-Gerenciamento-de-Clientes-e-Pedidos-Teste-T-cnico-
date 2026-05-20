public class ControllerProduct : ControllerBase

{

    public readonly IproductRepository CreateProductAsync; 

    public IproductRepository(IproductRepository createProductAsync)
    {
        CreateProductAsync = createProductAsync;
    }

    [HttpPost("signup")]
    [ApiController]
    [Route("api/[controller]")]

    public IActionResult Post()
    {
        return Ok("Post method called");
    }

    [HttpPost("")]
    public IActionResult Post()
    {
        return Ok("Post method called");
    }

    [HttpPost("")]
    public IActionResult Post()
    {
        return Ok("Post method called");
    }

    [HttpPost("")]
    public IActionResult Post()
    {
        return Ok("Post method called");
    }
    [HttpPut]
    public IActionResult Put()
    {
        return Ok("Put method called");
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Get method called");
    }
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok("Delete method called");
    }
}