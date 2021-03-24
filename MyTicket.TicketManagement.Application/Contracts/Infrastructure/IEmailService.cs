using MyTicket.TicketManagement.Application.Models.Mail;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
