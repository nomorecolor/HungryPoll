using Google.Apis.Auth;
using HungryPoll.Domain.Models;
using HungryPoll.Handler.Food;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HungryPoll.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly HungryPollContext _context;

		public AuthController(IMediator mediator, HungryPollContext context)
		{
			_mediator = mediator;
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var query = new GetFoodVoteQuery();
			var result = await _mediator.Send(query);

			return Ok(result);
		}


		[AllowAnonymous]
		[HttpPost("verify")]
		public async Task<ActionResult> Verify()
		{
			var token = Request.Headers["Authorization"].ToString().Remove(0, 7);

			var payload = await VerifyGoogleTokenId(token);

			if (payload == null)
			{
				return BadRequest("Invalid token");
			}

			return Ok("Login");
		}

		private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleTokenId(string token)
		{
			GoogleJsonWebSignature.Payload payload = null!;
			try
			{
				var validationSettings = new GoogleJsonWebSignature.ValidationSettings
				{
					Audience = new string[] { "151961832289-klcqa03ajk2ph4i1941mt0ika5aicmiq.apps.googleusercontent.com" },
					ForceGoogleCertRefresh = true
				};

				payload = await GoogleJsonWebSignature.ValidateAsync(token, validationSettings);
			}
			catch (InvalidJwtException)
			{
				return null!;
			}

			return payload;
		}
	}
}
