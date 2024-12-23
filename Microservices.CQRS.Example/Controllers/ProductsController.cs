#region Manuel CQRS
//using Microservices.CQRS.Example.Manual_CQRS.Commands.Request;
//using Microservices.CQRS.Example.Manual_CQRS.Handlers.CommandHandlers;
//using Microservices.CQRS.Example.Manual_CQRS.Handlers.QueryHandlers;
//using Microservices.CQRS.Example.Manual_CQRS.Queries.Requests;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Microservices.CQRS.Example.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController(CreateProductCommandHandler createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetAllProductQueryHandler getAllProductQueryHandler, GetByIdProductQueryHandler getByIdProductQueryHandler) : ControllerBase
//    {
//        [HttpGet]
//        public IActionResult Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
//        {
//            return Ok(getAllProductQueryHandler.GetAllProduct(getAllProductQueryRequest));
//        }

//        [HttpGet("{ProductId}")]
//        public IActionResult Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
//        {
//            return Ok(getByIdProductQueryHandler.GetByIdProduct(getByIdProductQueryRequest));
//        }
//        [HttpPost]
//        public IActionResult Post([FromBody] CreateProductCommandRequest createProductCommandRequest)
//        {
//            return Ok(createProductCommandHandler.CreateProduct(createProductCommandRequest));
//        }

//        [HttpDelete("{ProductId}")]
//        public IActionResult Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
//        {
//            return Ok(deleteProductCommandHandler.DeleteProduct(deleteProductCommandRequest));
//        }


//    }
//}

#endregion
#region MediatR CQRS
using MediatR;
using Microservices.CQRS.Example.MediatR_CQRS.Commands.Request;
using Microsoft.AspNetCore.Mvc;
using GetAllProductQueryRequest = Microservices.CQRS.Example.MediatR_CQRS.Queries.Requests.GetAllProductQueryRequest;
using GetByIdProductQueryRequest = Microservices.CQRS.Example.MediatR_CQRS.Queries.Requests.GetByIdProductQueryRequest;

namespace Microservices.CQRS.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest request)
        {
            return Ok(mediator.Send(request));
        }

        [HttpGet("{ProductId}")]
        public IActionResult Get([FromRoute] GetByIdProductQueryRequest request)
        {
            return Ok(mediator.Send(request));
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest request)
        {
            return Ok(mediator.Send(request));
        }

        [HttpDelete("{ProductId}")]
        public IActionResult Delete([FromRoute] DeleteProductCommandRequest request)
        {
            return Ok(mediator.Send(request));
        }


    }
}
#endregion
