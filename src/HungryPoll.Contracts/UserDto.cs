namespace HungryPoll.Contracts
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
    }
}
