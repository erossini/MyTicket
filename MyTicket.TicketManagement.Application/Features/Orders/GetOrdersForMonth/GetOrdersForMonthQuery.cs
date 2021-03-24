using MediatR;
using System;

namespace MyTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthVm>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
