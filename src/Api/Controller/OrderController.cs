using Microsoft.AspNetCore.Mvc;
using Application.Customers;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces;

[ApiController]
[Route("api/oder")]
public class OderController : ControllerBase
{
    public readonly CreateUser createUser;
    public readonly IUserRepository _userRepository;

    public OderController (CreateUser createUser, IUserRepository _userRepository)
    {
        
    }
}
