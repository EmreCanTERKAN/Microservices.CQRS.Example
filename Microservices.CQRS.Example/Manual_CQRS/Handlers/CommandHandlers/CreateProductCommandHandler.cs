using Microservices.CQRS.Example.Manual_CQRS.Commands.Request;
using Microservices.CQRS.Example.Manual_CQRS.Commands.Responses;
using Microservices.CQRS.Example.Models;

namespace Microservices.CQRS.Example.Manual_CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {
        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = createProductCommandRequest.Name,
                Quantity = createProductCommandRequest.Quantity,
                Price = createProductCommandRequest.Price,
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
