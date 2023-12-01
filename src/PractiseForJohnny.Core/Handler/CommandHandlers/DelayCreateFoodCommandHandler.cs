using Hangfire;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class DelayCreateFoodCommandHandler : ICommandHandler<DelayCreateFoodCommand>
{
    private readonly IFoodService _foodService;

    public DelayCreateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task Handle(IReceiveContext<DelayCreateFoodCommand> context, CancellationToken cancellationToken)
    {
        await _foodService.DelayCreateFood(context.Message, cancellationToken);
    }
}