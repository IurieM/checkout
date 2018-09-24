using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basket.Api.Commands;
using MediatR;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;

        public BasketController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var query = new GetUserBasketQuery() { UserId = userId };
            var basket = await mediator.Send(query);
            if (basket == null)
            {
                var command = new CreateBasketCommand() { UserId = query.UserId };
                basket = await mediator.Send(command);
            }
            return Ok(basket);
        }

        [HttpPut("clear")]
        public async Task<IActionResult> ClearBasket([FromBody] ClearBasketCommand command)
        {
            var basket = await mediator.Send(command);
            return Ok(basket);
        }

        [HttpPut("item/add")]
        public async Task<IActionResult> AddItem([FromBody] AddBasketItemCommand command)
        {
            var basketItem = await mediator.Send(command);
            return Ok(basketItem);
        }

        [HttpPut("item/delete")]
        public async Task<IActionResult> DeleteItem([FromBody] DeleteBasketItemCommand command)
        {
            var itemId = await mediator.Send(command);
            return Ok(itemId);
        }

        [HttpPut("item/units")]
        public async Task<IActionResult> SetItemUnits([FromBody] SetBasketItemUnitsCommand command)
        {
            var itemUnits = await mediator.Send(command);
            return Ok(itemUnits);
        }
    }
}
