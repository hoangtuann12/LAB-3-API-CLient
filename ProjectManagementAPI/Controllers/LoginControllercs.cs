using BusinessObjects.Entities;
using DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
namespace IdentityAjaxClient.ApiControllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly LoginDAO _loginDAO;

    public LoginController(LoginDAO loginDAO)
    {
        _loginDAO = loginDAO;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var account = _loginDAO.Login(request.Email, request.Password);
        if (account == null)
        {
            return Unauthorized("Invalid email or password.");
        }
        return Ok(new { account.AccountId, account.AccountName, account.Email });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] Account account)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);  // Giúp debug dễ hơn

        if (_loginDAO.IsEmailExists(account.Email))
            return BadRequest("Email already exists.");

        _loginDAO.Register(account);
        return Ok("Account registered successfully.");
    }

}

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
