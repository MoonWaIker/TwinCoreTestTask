using System.Data;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwinCoreTestTask.Core.Enums;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Controllers;

[ApiController]
[Authorize(Roles = nameof(Roles.Admin))]
// TODO Assign role
[Route(_route)]
public class AdminController(IAdminService service) : ControllerBase
{
    private const string _route = "api/[controller]";
    private static readonly string _authControllerName = nameof(AuthController)
        .Replace(nameof(Controller), string.Empty, StringComparison.OrdinalIgnoreCase);

    [HttpPost]
    public async Task<IActionResult> SendRegistrationInvite([FromBody] MailAddress address)
    {
        await service.SendInviteAsync(address,
            Url.Action(nameof(AuthController.Register), _authControllerName)
                            ?? throw new NoNullAllowedException());

        return Ok();
    }
}
