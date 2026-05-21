
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Dtos;

namespace Api.Controller;

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
            request.NameUser,
            request.Email,
            request.Password,
            request.UserType,
            request.Address
        );

        return Ok(user);
    }

    [HttpPost("login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await IUserRepository.GetByEmailAsync(request.Password);

        if (user == null)
        return Unauthorized("Not found user");

        var passwordHash = _hashService.generateSha256(request.Password);
        if(user.PasswordHash != passwordHash)
            return Unauthorized("Invalid password");

        return Ok("Login OK");        
    }

}