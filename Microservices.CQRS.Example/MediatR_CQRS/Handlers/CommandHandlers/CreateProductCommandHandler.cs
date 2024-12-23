using MediatR;
using Microservices.CQRS.Example.MediatR_CQRS.Commands.Responses;
using Microservices.CQRS.Example.Models;
using CreateProductCommandRequest = Microservices.CQRS.Example.MediatR_CQRS.Commands.Request.CreateProductCommandRequest;

namespace Microservices.CQRS.Example.MediatR_CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price,
                CreateTime = DateTime.Now
            });

            return new CreateProductCommandResponse()
            {
                ProductId = id,
                IsSuccess = true
            };
        }
    }
}
