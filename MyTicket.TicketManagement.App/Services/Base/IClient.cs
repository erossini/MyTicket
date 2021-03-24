using System.Net.Http;

namespace MyTicket.TicketManagement.App.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
