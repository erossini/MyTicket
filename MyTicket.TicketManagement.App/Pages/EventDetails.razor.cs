using MyTicket.TicketManagement.App.Contracts;
using MyTicket.TicketManagement.App.Services.Base;
using MyTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyTicket.TicketManagement.App.Pages
{
    public partial class EventDetails
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EventDetailViewModel EventDetailViewModel { get; set; } 
            = new EventDetailViewModel() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<CategoryViewModel> Categories { get; set; } 
            = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string EventId { get; set; }
        private Guid SelectedEventId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                EventDetailViewModel = await EventDataService.GetEventById(SelectedEventId);
                SelectedCategoryId = EventDetailViewModel.CategoryId.ToString();
            }

            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            EventDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedEventId == Guid.Empty)
            {
                response = await EventDataService.CreateEvent(EventDetailViewModel);
            }
            else
            {
                 response = await EventDataService.UpdateEvent(EventDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeleteEvent()
        {
            var response = await EventDataService.DeleteEvent(SelectedEventId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/eventoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/eventoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
