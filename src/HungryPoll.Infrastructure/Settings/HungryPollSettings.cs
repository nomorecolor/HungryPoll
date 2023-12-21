using Microsoft.Extensions.Configuration;

namespace HungryPoll.Infrastructure.Settings
{
	public interface IHungryPollSettings
	{
		string ConnectionString { get; }
	}

	public class HungryPollSettings : IHungryPollSettings
	{
		public string ConnectionString => _configuration.GetConnectionString("HungryPoll")!;

		private readonly IConfiguration _configuration;

		public HungryPollSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}
	}
}
