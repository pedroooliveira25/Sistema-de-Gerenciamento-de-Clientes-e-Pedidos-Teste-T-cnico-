using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly CreateUser _createUser;

    public AuthController(CreateUser createUser)
    {
        _createUser = createUser;
    }

    [HttpPost("signup")]
    [AllowAnonymous]
    public async Task<IActionResult> Signup([FromBody] SignupRequest request)
    {
        var user = await _createUser.Execute(
            request.Name,
            request.Email,
            request.Password,
            request.UserType
        );

        return Ok(user);
    }

    [HttpPost()]
}