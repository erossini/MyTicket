using MyTicket.TicketManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
