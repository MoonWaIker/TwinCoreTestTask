using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using TwinCoreTestTask.DataBase.Contexts;
using TwinCoreTestTask.DataBase.Entities;
using TwinCoreTestTask.Infrastructure.Services.Interfaces;

namespace TwinCoreTestTask.Infrastructure.Services;

public sealed class AdminService(
    ISendGridClient sendGrid,
                            TwinCoreDbContext dbContext,
                            TimeProvider timeProvider) : IAdminService
{
    private const string HtmlBody = "<strong>Heya, you've received an invitation to the Diary Service!</strong>";
    private const string InvitationSubject = "Invitation to registration for the diary service";

    // We would use the admin email that sends an invite, but registration for SendGrid is required
    private static readonly EmailAddress SenderEmail = new("muhinmihajlo40@gmail.com");

    // TODO Check if you can get host address via more convenient way
    public async Task SendInviteAsync(MailAddress mailAddress, string handlerAddress)
    {
        var token = Guid.NewGuid();

        await AddTokenToDbAsync(token, mailAddress.Address);

        var response = await sendGrid.SendEmailAsync(MailHelper.CreateSingleEmail(SenderEmail,
                                                                    new(mailAddress.Address),
                                                                    InvitationSubject,
                                                                    handlerAddress + token,
                                                                    HtmlBody));

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException();
        }
    }

    private async Task AddTokenToDbAsync(Guid token, string email)
    {
        dbContext.RegisterInvitations.Add(new RegisterInvitation
        {
            Email = email,
            Token = token,
            ExpiresAt = timeProvider.GetUtcNow().AddDays(1).UtcDateTime,
        });
        await dbContext.SaveChangesAsync();
    }
}
