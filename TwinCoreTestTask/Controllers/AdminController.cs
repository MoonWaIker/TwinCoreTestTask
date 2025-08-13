using Microsoft.AspNetCore.Mvc;

namespace TwinCoreTestTask.Controllers;

[ApiController]
// TODO Assign role
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
