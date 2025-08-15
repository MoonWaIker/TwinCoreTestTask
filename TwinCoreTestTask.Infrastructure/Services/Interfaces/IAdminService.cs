using System.Net.Mail;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface IAdminService
{
    Task SendInviteAsync(MailAddress mailAddress, string handlerAddress);
}
