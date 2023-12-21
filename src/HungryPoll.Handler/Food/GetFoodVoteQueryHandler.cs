using HungryPoll.Contracts;
using HungryPoll.Domain.Models;
using HungryPoll.Handler.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HungryPoll.Handler.Food
{
	public record GetFoodVoteQuery : IRequest<IEnumerable<FoodVoteDto>>;

	public class GetFoodVoteQueryHandler : IRequestHandler<GetFoodVoteQuery, IEnumerable<FoodVoteDto>>
	{
		private readonly HungryPollContext _context;

		public GetFoodVoteQueryHandler(HungryPollContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<FoodVoteDto>> Handle(GetFoodVoteQuery request, CancellationToken cancellationToken)
		{
			var foodVotes = await _context.FoodVotes
				.Include(x => x.User)
				.ToListAsync();

			var foodVoteDtos = _context.Foods
				.Include(x => x.CreatedByUser)
				.ToList()
				.Select(x => new FoodVoteDto
				{
					FoodName = x.Name,
					CreatedByUser = x.CreatedByUser.ToDto(),
					Voters = foodVotes
						.Where(y => y.FoodId == x.Id)
						.Select(y => y.User.ToDto())
				});

			return foodVoteDtos;
		}
	}
}
