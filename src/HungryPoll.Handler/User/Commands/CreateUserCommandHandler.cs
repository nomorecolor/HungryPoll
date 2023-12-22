using HungryPoll.Contracts;
using HungryPoll.Domain.Models;
using HungryPoll.Handler.Utilities.Mappers;
using MediatR;

namespace HungryPoll.Handler.User.Commands
{
	public record CreateUserCommand(UserDto UserDto) : IRequest<UserDto>;

	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
	{
		private readonly HungryPollContext _context;

		public CreateUserCommandHandler(HungryPollContext context)
		{
			_context = context;
		}

		public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new Domain.Models.User
			{
				FirstName = request.UserDto.FirstName,
				LastName = request.UserDto.LastName,
				ExternalId = request.UserDto.ExternalId,
				Email = request.UserDto.Email,
				ImageUrl = request.UserDto.ImageUrl,
			};

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync(cancellationToken);

			return user.ToDto();
		}
	}
}
