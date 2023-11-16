using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class DeleteFoodCommandHandler : ICommandHandler<DeleteFoodCommand,DeleteFoodResponse>
{
    private readonly IFoodsService _foodsService;

    public DeleteFoodCommandHandler(IFoodsService foodsService)
    {
        _foodsService = foodsService;
    }

    public async Task<DeleteFoodResponse> Handle(IReceiveContext<DeleteFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodsService.DeleteFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);
        
        return new DeleteFoodResponse
        {
            Result = @event.Result
        };
    }
}