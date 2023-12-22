using HungryPoll.API.Filters;
using HungryPoll.Contracts;
using HungryPoll.Handler.Food.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HungryPoll.API.Controllers
{
	[TypeFilter(typeof(GoogleAuthorizeAttribute))]
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FoodController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> CreateFood(FoodDto foodDto)
		{
			var command = new CreateFoodCommand(foodDto);

			var result = await _mediator.Send(command);

			return Ok(result);
		}
	}
}
