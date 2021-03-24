using MyTicket.TicketManagement.Application.Models.Authentication;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
