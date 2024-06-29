using AmusementPark.Core.Services.Food;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Handler.RequestHandlers;

public class GetFoodRequestHandler : IRequestHandler<GetFoodRequest, GetFoodResponse>
{
    private readonly IFoodService _foodService;

    public GetFoodRequestHandler(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public async Task<GetFoodResponse> Handle(IReceiveContext<GetFoodRequest> context, CancellationToken cancellationToken)
    {
        return new GetFoodResponse
        {
            Result = await _foodService.GetFoodAsync(context.Message, cancellationToken).ConfigureAwait(false)
        };
    }
}