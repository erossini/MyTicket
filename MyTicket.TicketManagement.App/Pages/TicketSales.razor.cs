using MyTicket.TicketManagement.App.Components;
using MyTicket.TicketManagement.App.Contracts;
using MyTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Pages
{
    public partial class TicketSales
    {

        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string SelectedMonth { get; set; }
        public string SelectedYear { get; set; }

        public List<string> MonthList { get; set; } = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> YearList { get; set; } = new List<string>() { "2020", "2021", "2022" };

        private int? pageNumber = 1;

        private PaginatedList<OrdersForMonthListViewModel> paginatedList 
            = new PaginatedList<OrdersForMonthListViewModel>();

        private IEnumerable<OrdersForMonthListViewModel> ordersList;

        protected async Task GetSales()
        {
            DateTime dt = new DateTime(int.Parse(SelectedYear), int.Parse(SelectedMonth), 1);

            var orders = await OrderDataService.GetPagedOrderForMonth(dt, pageNumber.Value, 5);
            paginatedList = new PaginatedList<OrdersForMonthListViewModel>(orders.OrdersForMonth.ToList(), orders.Count, pageNumber.Value, 5);
            ordersList = paginatedList.Items;

            StateHasChanged();
        }

        public async void PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
            {
                return;
            }
            pageNumber = newPageNumber;
            await GetSales();
            StateHasChanged();
        }
    }
}