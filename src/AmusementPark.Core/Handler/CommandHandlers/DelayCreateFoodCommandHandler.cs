using AmusementPark.Core.Services.Food;
using Hangfire;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Commands;

namespace AmusementPark.Core.Handler.CommandHandlers;

public class DelayCreateFoodCommandHandler : ICommandHandler<DelayCreateFoodCommand>
{
    private readonly IFoodService _foodService;

    public DelayCreateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public Task Handle(IReceiveContext<DelayCreateFoodCommand> context, CancellationToken cancellationToken)
    {
        _foodService.DelayCreateFood(context.Message, cancellationToken);

        return Task.CompletedTask;
    }
}