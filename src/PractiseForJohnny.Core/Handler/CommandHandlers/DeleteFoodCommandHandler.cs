using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand,DeleteFoodResponse>
{
    private readonly IFoodService _foodService;

    public DeleteFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<DeleteFoodResponse> Handle(IReceiveContext<DeleteFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodService.DeleteFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);
        
        return new DeleteFoodResponse
        {
            Result = @event.Result
        };
    }
}