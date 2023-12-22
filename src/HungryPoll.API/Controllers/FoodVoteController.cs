using HungryPoll.API.Filters;
using HungryPoll.Contracts;
using HungryPoll.Handler.FoodVote.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HungryPoll.API.Controllers
{
	[TypeFilter(typeof(GoogleAuthorizeAttribute))]
	[Route("api/[controller]")]
	[ApiController]
	public class FoodVoteController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FoodVoteController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<FoodVoteDto>>> GetAll()
		{
			var query = new GetFoodVoteQuery();

			var result = await _mediator.Send(query);

			return Ok(result);
		}
	}
}
