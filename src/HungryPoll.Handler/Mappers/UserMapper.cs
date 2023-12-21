using HungryPoll.Contracts;
using HungryPoll.Domain.Models;

namespace HungryPoll.Handler.Mappers
{
	public static class UserMapper
	{
		public static UserDto ToDto(this User user)
		{
			return new UserDto
			{
				Id = user.Id,
				Name = $"{user.FirstName} {user.LastName}",
				ImageUrl = user.ImageUrl
			};
		}
	}
}
