using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class RecurringUpdateFoodCommandHandler : ICommandHandler<RecurringUpdateFoodCommand>
{
    private readonly IFoodService _foodService;

    public RecurringUpdateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public Task Handle(IReceiveContext<RecurringUpdateFoodCommand> context, CancellationToken cancellationToken)
    {
        _foodService.RecurringUpdateFood(context.Message, cancellationToken);

        return Task.CompletedTask;
    }
}