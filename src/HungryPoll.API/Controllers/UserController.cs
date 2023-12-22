using HungryPoll.API.Filters;
using HungryPoll.Contracts;
using HungryPoll.Handler.User.Commands;
using HungryPoll.Handler.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HungryPoll.API.Controllers
{
	[TypeFilter(typeof(GoogleAuthorizeAttribute))]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> GetOrCreate(UserDto userDto)
		{
			var query = new GetUserQuery(userDto.ExternalId);

			var result = await _mediator.Send(query);

			if (result == null)
			{
				var command = new CreateUserCommand(userDto);

				result = await _mediator.Send(command);
			}

			return Ok(result);
		}
	}
}
