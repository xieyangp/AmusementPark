using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class GetFoodCommandHandler : ICommandHandler<GetFoodCommand, GetFoodResponse>
{
    private readonly IFoodService _foodService;

    public GetFoodCommandHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<GetFoodResponse> Handle(IReceiveContext<GetFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodService.GetFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new GetFoodResponse
        {
            Result = @event.Result
        };
    }
}