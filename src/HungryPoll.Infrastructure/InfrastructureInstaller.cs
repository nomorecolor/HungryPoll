using HungryPoll.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace HungryPoll.Infrastructure
{
	public static class InfrastructureInstaller
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddSingleton<IHungryPollSettings, HungryPollSettings>();

			return services;
		}
	}
}
