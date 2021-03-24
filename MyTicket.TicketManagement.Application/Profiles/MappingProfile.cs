using AutoMapper;
using MyTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using MyTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using MyTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MyTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using MyTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using MyTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using MyTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using MyTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using MyTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;
using MyTicket.TicketManagement.Domain.Entities;

namespace MyTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
