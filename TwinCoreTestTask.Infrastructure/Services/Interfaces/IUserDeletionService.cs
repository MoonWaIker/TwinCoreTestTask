using System.Net.Mail;

namespace TwinCoreTestTask.Infrastructure.Services.Interfaces;

public interface IUserDeletionService
{
    Task DeleteUserAsync(MailAddress email);

    Task RecoverAccountAsync(MailAddress email);
}
