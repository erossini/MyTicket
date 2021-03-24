using AutoMapper;
using Blazored.LocalStorage;
using MyTicket.TicketManagement.App.Contracts;
using MyTicket.TicketManagement.App.Services.Base;
using MyTicket.TicketManagement.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Services
{
    public class OrderDataService : BaseDataService, IOrderDataService
    {
        private readonly IMapper _mapper;

        public OrderDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size)
        {
            var orders = await _client.GetPagedOrdersForMonthAsync(date, page, size);
            var mappedOrders = _mapper.Map<PagedOrderForMonthViewModel>(orders);
            return mappedOrders;
        }
    }
}
