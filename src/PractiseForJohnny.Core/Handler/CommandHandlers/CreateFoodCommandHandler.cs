using Mediator.Net.Context;
using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Services.Food;
using PractiseForJohnny.Message.Commands;

namespace PractiseForJohnny.Core.Handler.CommandHandlers;

public class CreateFoodCommandHandler : ICommandHandler<CreateFoodCommand, CreateFoodResponse>
{
    private readonly IFoodsService _foodsService;

    public CreateFoodCommandHandler(IFoodsService foodsService)
    {
        _foodsService = foodsService;
    }

    public async Task<CreateFoodResponse> Handle(IReceiveContext<CreateFoodCommand> context, CancellationToken cancellationToken)
    {
        var @event = await _foodsService.CreateFoodAsync(context.Message, cancellationToken).ConfigureAwait(false);

        await context.PublishAsync(@event, cancellationToken).ConfigureAwait(false);

        return new CreateFoodResponse
        {
            Result = @event.Result
        };
    }
}