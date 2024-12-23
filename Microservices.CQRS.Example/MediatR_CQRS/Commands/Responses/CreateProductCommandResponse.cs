using MediatR;

namespace Microservices.CQRS.Example.MediatR_CQRS.Commands.Responses
{
    public class CreateProductCommandResponse : IRequest<CreateProductCommandResponse>
    {
        public bool IsSuccess { get; set; }
        public Guid ProductId { get; set; }
    }
}
