using BabyName.Models.DTOs;
using BabyName.Models.Login;
using BabyName.Services;
using BabyName.Utils.ResultPattern;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabyName.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService _authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Login([FromBody] LoginRequest login)
    {
        var result = await _authService.AuthenticateAsync(login);
        return result.ToActionResult();
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> RegisterAsync([FromBody] UserModel user)
    {
        var result = await _authService.RegisterUser(user);
        return result.ToActionResult();
    }

    [HttpPost("recoverpassword")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> RecoverPasswordAsync([FromBody] RecoverPasswordRequest request)
    {
        var result = await _authService.RecoverPassword(request);
        return result.ToActionResult();
    }
}