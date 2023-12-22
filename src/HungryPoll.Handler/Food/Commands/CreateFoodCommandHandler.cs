using HungryPoll.Contracts;
using HungryPoll.Domain.Models;
using MediatR;

namespace HungryPoll.Handler.Food.Commands
{
	public record CreateFoodCommand(FoodDto FoodDto) : IRequest<Guid?>;

	public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Guid?>
	{
		private readonly HungryPollContext _context;

		public CreateFoodCommandHandler(HungryPollContext context)
		{
			_context = context;
		}

		public async Task<Guid?> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
		{
			var food = new Domain.Models.Food
			{
				Name = request.FoodDto.Name,
				CreatedByUserId = request.FoodDto.CreatedByUserId,
				CreatedOn = DateTime.Now,
			};

			await _context.Foods.AddAsync(food);
			await _context.SaveChangesAsync(cancellationToken);

			return food.Id;
		}
	}
}
