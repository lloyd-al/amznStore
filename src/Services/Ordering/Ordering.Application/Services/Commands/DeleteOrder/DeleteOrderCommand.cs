using MediatR;

namespace amznStore.Services.Ordering.Application.Services.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
