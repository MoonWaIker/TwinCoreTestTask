using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwinCoreTestTask.Core.Utils;

namespace TwinCoreTestTask.Controllers;

[ApiController]
[Authorize(Roles = RolesStrings.Admin)]
[Route(_route)]
public class AdminController : ControllerBase
{
    private const string _route = "api/[controller]";

    [HttpPost]
    public Task<IActionResult> SendRegistrationInvite()
    {
        throw new NotImplementedException();
    }
}
