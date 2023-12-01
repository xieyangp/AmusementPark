using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class ScheduleUpdateFoodCommandHandler : ICommandHandler<ScheduleUpdateFoodCommand>
{
    private readonly IFoodService _foodService;

    public ScheduleUpdateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }
    
    public async Task Handle(IReceiveContext<ScheduleUpdateFoodCommand> context, CancellationToken cancellationToken)
    {
        await _foodService.ScheduleUpdateFood(context.Message, cancellationToken);
    }
}