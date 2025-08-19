using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Controllers;

[ApiController]
[Route(_route)]
public sealed class UserDeletionController(IUserDeletionService userDeletionService) : ControllerBase
{
    private const string _route = "api/[controller]";

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] MailAddress email)
    {
        await userDeletionService.DeleteUserAsync(email);

        return NoContent();
    }

    [HttpPatch]
    public async Task<IActionResult> RecoverAccount([FromQuery] MailAddress email)
    {
        await userDeletionService.RecoverAccountAsync(email);

        return NoContent();
    }
}
