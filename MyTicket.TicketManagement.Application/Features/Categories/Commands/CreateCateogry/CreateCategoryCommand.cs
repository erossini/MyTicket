using MediatR;

namespace MyTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommand: IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
