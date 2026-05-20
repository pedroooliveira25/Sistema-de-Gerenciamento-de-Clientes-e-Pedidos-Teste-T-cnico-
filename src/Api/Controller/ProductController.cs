public class ControllerProduct : ControllerBase
{    
[ApiController]
[Route("api/[controller]")]

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


   [ HttpGet]
        public IActionResult Get()
        {
            return Ok("Get method called");
        }
}