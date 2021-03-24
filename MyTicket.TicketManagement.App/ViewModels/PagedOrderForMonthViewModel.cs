using System.Collections.Generic;

namespace MyTicket.TicketManagement.App.ViewModels
{
    public class PagedOrderForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthListViewModel> OrdersForMonth { get; set; }
    }
}
