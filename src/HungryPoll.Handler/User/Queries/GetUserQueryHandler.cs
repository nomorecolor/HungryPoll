using HungryPoll.Contracts;
using HungryPoll.Domain.Models;
using HungryPoll.Handler.Utilities.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HungryPoll.Handler.User.Queries
{
	public record GetUserQuery(string ExternalId) : IRequest<UserDto>;

	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto?>
	{
		private readonly HungryPollContext _context;

		public GetUserQueryHandler(HungryPollContext context)
		{
			_context = context;
		}

		public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			var userDto = await _context.Users
				.Where(x => x.ExternalId == request.ExternalId)
				.Select(x => x.ToDto())
				.FirstOrDefaultAsync();

			return userDto;
		}
	}
}
