using Google.Apis.Auth;
using HungryPoll.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HungryPoll.API.Filters
{
	public class GoogleAuthorizeAttribute : IAsyncAuthorizationFilter
	{
		private readonly IHungryPollSettings _settings;

		public GoogleAuthorizeAttribute(IHungryPollSettings settings)
		{
			_settings = settings;
		}

		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			try
			{
				var token = context.HttpContext.Request.Headers["Authorization"].ToString().Remove(0, 7);

				var validationSettings = new GoogleJsonWebSignature.ValidationSettings
				{
					Audience = new string[] { _settings.Google.ClientId },
				};

				await GoogleJsonWebSignature.ValidateAsync(token, validationSettings);
			}
			catch (Exception)
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
