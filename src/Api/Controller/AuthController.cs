
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.Dtos;
namespace Api.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{   
    private readonly TokenService _tokenService;
    private readonly IUserRepository _userRepository;
    private readonly HashService _hashService;
    private readonly CreateUser _createUser;
    public AuthController(CreateUser createUser, HashService hashService, IUserRepository userRepository, TokenService tokenService)
    {
        _createUser = createUser;
        _hashService = hashService;
        _userRepository = userRepository;
        _tokenService = tokenService;
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

    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
       
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null)
        return Unauthorized("Not found user");

        var passwordHash = _hashService.GenerateSha256(request.Password);

        if(user.Password != passwordHash)
            return Unauthorized("Invalid password");
      
    
       var token = _tokenService.GenerateToken(
            user.Id,
            user.NameUser,
            user.Email
       );

        return Ok(new{ token });        
    }

}