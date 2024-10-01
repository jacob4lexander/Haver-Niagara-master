using System.Net.Mail;
using Haver_Niagara.ViewModels;

namespace Haver_Niagara.ViewModels
{
    /// <summary>
    /// Interface for my own email service
    /// </summary>
    public interface IMyEmailSender
    {
        Task SendOneAsync(string name, string email, string subject, string htmlMessage);
        Task SendToManyAsync(EmailMessage emailMessage);
    }
}
