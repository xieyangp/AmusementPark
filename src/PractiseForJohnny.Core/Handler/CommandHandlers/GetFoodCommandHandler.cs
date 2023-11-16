using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class GetFoodCommandHandler : ICommandHandler<GetFoodCommand, GetFoodResponse>
{
    private readonly IFoodsService _foodsService;

    public GetFoodCommandHandler(IFoodsService foodsService)
    {
        _foodsService = foodsService;
    }

    public async Task<GetFoodResponse> Handle(IReceiveContext<GetFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodsService.GetFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new GetFoodResponse
        {
            Result = @event.Result
        };
    }
}