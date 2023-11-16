using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class UpdateFoodCommandHandler : ICommandHandler<UpdateFoodCommand, UpdateFoodResponse>
{
    private readonly IFoodsService _foodsService;

    public UpdateFoodCommandHandler(IFoodsService foodsService)
    {
        _foodsService = foodsService;
    }

    public async Task<UpdateFoodResponse> Handle(IReceiveContext<UpdateFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodsService.UpdateFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new UpdateFoodResponse
        {
            Result = @event.Result
        };
    }
}