using MyTicket.TicketManagement.App.Services.Base;
using MyTicket.TicketManagement.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Contracts
{
    public interface IEventDataService
    {
        Task<List<EventListViewModel>> GetAllEvents();
        Task<EventDetailViewModel> GetEventById(Guid id);
        Task<ApiResponse<Guid>> CreateEvent(EventDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> UpdateEvent(EventDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> DeleteEvent(Guid id);
    }
}
