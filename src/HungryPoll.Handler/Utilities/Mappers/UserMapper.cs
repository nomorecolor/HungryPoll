using HungryPoll.Contracts;

namespace HungryPoll.Handler.Utilities.Mappers
{
	public static class UserMapper
	{
		public static UserDto ToDto(this Domain.Models.User user)
		{
			return new UserDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				ExternalId = user.ExternalId,
				Email = user.Email,
				ImageUrl = user.ImageUrl
			};
		}
	}
}
