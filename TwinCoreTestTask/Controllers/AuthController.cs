using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwinCoreTestTask.Infrastructure.DTOs;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;
using TwinCoreTestTask.Utils;

namespace TwinCoreTestTask.Controllers;

[ApiController]
[Route(_route)]
public class AuthController(ILoginService loginService) : ControllerBase
{
    private const string _route = "api/[controller]";

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserCredentials credentials)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!loginService.TryValidateCredentials(credentials, out var user))
        {
            return Unauthorized();
        }

        await HttpContext.AuthorizeUserAsync(user);

        return Ok();
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Ok();
    }
}
