using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Restaurants.Command.CreateRestaurant;
using Restaurant.Application.Restaurants.Command.DeleteRestaurant;
using Restaurant.Application.Restaurants.Dtos;
using Restaurant.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurant.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
                return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var restaurants = await mediator.Send(new GetRestaurantByIdQuery(id));

            if(restaurants is null)
                return NotFound();

            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, UpdateRestaurantCommand command)
        {
            var isUpdate = await mediator.Send(new UpdateRestaurantCommand(id));

            if (restaurants is null)
                return NotFound();

            return Ok(restaurants);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteRestaurantCommand(id));

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

    }
}
