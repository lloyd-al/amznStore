using System.Threading.Tasks;
using amznStore.Common.Core.Entities;

namespace amznStore.Common.Core.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailMessage emailMessage);
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
