namespace HungryPoll.Contracts
{
	public class FoodDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = null!;
		public Guid CreatedByUserId { get; set; }
	}
}
