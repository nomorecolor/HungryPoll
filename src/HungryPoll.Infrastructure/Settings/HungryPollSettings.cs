using Microsoft.Extensions.Configuration;

namespace HungryPoll.Infrastructure.Settings
{
	public interface IHungryPollSettings
	{
		string ConnectionString { get; }
		GoogleSettings Google { get; }
	}

	public class HungryPollSettings : IHungryPollSettings
	{
		public string ConnectionString => _configuration.GetConnectionString("HungryPoll")!;
		public GoogleSettings Google => _configuration.GetSection(nameof(Google)).Get<GoogleSettings>()!;

		private readonly IConfiguration _configuration;

		public HungryPollSettings(IConfiguration configuration)
		{
			_configuration = configuration;
		}
	}
}
