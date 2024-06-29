using AmusementPark.Core.Services.Food;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Commands;

namespace AmusementPark.Core.Handler.CommandHandlers;

public class UpdateFoodCommandHandler : ICommandHandler<UpdateFoodCommand, UpdateFoodResponse>
{
    private readonly IFoodService _foodService;

    public UpdateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<UpdateFoodResponse> Handle(IReceiveContext<UpdateFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodService.UpdateFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new UpdateFoodResponse
        {
            Result = @event.Result
        };
    }
}