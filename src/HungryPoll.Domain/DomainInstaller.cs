using HungryPoll.Domain.Models;
using HungryPoll.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HungryPoll.Domain
{
	public static class DomainInstaller
	{
		public static IServiceCollection AddDomain(this IServiceCollection services)
		{
			services.AddDbContext<HungryPollContext>((serviceProvider, options) =>
			{
				var settings = serviceProvider.GetService<IHungryPollSettings>();

				options.UseSqlServer(settings!.ConnectionString);
			});

			return services;
		}
	}
}
