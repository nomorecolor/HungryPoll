using Microsoft.Extensions.DependencyInjection;

namespace HungryPoll.Handler
{
	public static class HandlerInstaller
	{
		public static IServiceCollection AddHandler(this IServiceCollection services)
		{
			services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(HandlerInstaller).Assembly));

			return services;
		}
	}
}
