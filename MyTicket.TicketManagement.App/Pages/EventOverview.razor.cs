using MyTicket.TicketManagement.App.Contracts;
using MyTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Pages
{
    public partial class EventOverview
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<EventListViewModel> Events { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Events = await EventDataService.GetAllEvents();
        }

        protected void AddNewEvent()
        {
            NavigationManager.NavigateTo("/eventdetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportEvents()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:5001/api/events/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }
    }
}
