using MyTicket.TicketManagement.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
