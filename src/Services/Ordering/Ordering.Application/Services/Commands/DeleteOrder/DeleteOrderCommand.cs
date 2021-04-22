using MediatR;

namespace amznStore.Services.Ordering.Application.Services.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
