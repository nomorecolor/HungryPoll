namespace HungryPoll.Contracts
{
	public class FoodVoteDto
	{
		public string FoodName { get; set; } = string.Empty;
		public UserDto CreatedByUser { get; set; } = null!;
		public IEnumerable<UserDto> Voters { get; set; } = Enumerable.Empty<UserDto>();
	}
}
