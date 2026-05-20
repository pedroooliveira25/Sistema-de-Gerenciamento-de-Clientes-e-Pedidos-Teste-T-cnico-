
[ApiController]
[Route("api/authUser")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _cutomerRepository;
    private readonly CreateUser hashService; 
}