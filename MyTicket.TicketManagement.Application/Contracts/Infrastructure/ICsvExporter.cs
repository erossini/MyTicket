using MyTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace MyTicket.TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
