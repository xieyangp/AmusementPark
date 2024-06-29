using AmusementPark.Core.Services.Food;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Commands;

namespace AmusementPark.Core.Handler.CommandHandlers;

public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand, CreateFoodResponse>
{
    private readonly IFoodService _foodService;

    public CreateFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<CreateFoodResponse> Handle(IReceiveContext<CreateFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodService.CreateFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new CreateFoodResponse
        {
            Result = @event.Result
        };
    }
}