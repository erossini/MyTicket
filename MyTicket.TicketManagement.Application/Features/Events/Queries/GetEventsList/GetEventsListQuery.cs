using MediatR;
using System.Collections.Generic;

namespace MyTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {

    }
}
