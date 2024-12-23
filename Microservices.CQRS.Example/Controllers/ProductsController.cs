using Microservices.CQRS.Example.Manual_CQRS.Commands.Request;
using Microservices.CQRS.Example.Manual_CQRS.Handlers.CommandHandlers;
using Microservices.CQRS.Example.Manual_CQRS.Handlers.QueryHandlers;
using Microservices.CQRS.Example.Manual_CQRS.Queries.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.CQRS.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(CreateProductCommandHandler createProductCommandHandler, DeleteProductCommandHandler deleteProductCommandHandler, GetAllProductQueryHandler getAllProductQueryHandler, GetByIdProductQueryHandler getByIdProductQueryHandler) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            return Ok(getAllProductQueryHandler.GetAllProduct(getAllProductQueryRequest));
        }

        [HttpGet("{ProductId}")]
        public IActionResult Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            return Ok(getByIdProductQueryHandler.GetByIdProduct(getByIdProductQueryRequest));
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            return Ok(createProductCommandHandler.CreateProduct(createProductCommandRequest));
        }

        [HttpDelete("{ProductId}")]
        public IActionResult Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            return Ok(deleteProductCommandHandler.DeleteProduct(deleteProductCommandRequest));
        }


    }
}
