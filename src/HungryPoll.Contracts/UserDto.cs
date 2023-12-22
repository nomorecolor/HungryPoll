namespace HungryPoll.Contracts
{
	public class UserDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string DisplayName => $"{FirstName} {LastName}";
		public string ExternalId { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
	}
}
