using MediatR;
using Microservices.CQRS.Example.MediatR_CQRS.Queries.Responses;
using Microservices.CQRS.Example.Models;
using GetByIdProductQueryRequest = Microservices.CQRS.Example.MediatR_CQRS.Queries.Requests.GetByIdProductQueryRequest;

namespace Microservices.CQRS.Example.MediatR_CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.ProductId);
            return new GetByIdProductQueryResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                CreateTime = product.CreateTime
            };
        }
    }
}
