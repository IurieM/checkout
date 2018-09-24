using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Catalog.Api.Queries;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> Get(string category)
        {
            var productList = await mediator.Send(new ProductsByCategoryQuery(category));
            return Ok(productList);
        }
    }
}
