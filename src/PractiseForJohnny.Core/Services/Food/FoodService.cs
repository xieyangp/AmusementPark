using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Food;

public class FoodService : IFoodService
{
    private readonly IMapper _mapper;
    private readonly IFoodDataProvider _foodDataProvider;
    public FoodService(IMapper mapper, IFoodDataProvider foodDataProvider)
    {
        _mapper = mapper;
        _foodDataProvider = foodDataProvider;
    }

    public async Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken)
    { 
        var food = await _foodDataProvider.CreatedFoodAsync(_mapper.Map<Foods>(command.Food), cancellationToken).ConfigureAwait(false);
        
        return new FoodCreatedEvent
        {
            Result = _mapper.Map<FoodCreatedDto>(food)
        };
    }

    public async Task<FoodUpdatedEvent> UpdateFoodAsync(UpdateFoodCommand command,CancellationToken cancellationToken)
    {
        await _foodDataProvider.UpdatedFoodAsync(command.Food, cancellationToken);
        
        return new FoodUpdatedEvent()
        {
            Result = _mapper.Map<FoodUpdatedDto>(command.Food)
        };
    }

    public async Task<FoodDeletedEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.DeletedFoodAsync(command.Food, cancellationToken);
        
        return new FoodDeletedEvent()
        {
            Result = _mapper.Map<FoodDeletedDto>(food)
        };
    }

    public async Task<FoodGetEvent> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken)
    {
        return new FoodGetEvent
        {
            Result = await _foodDataProvider.GetFoodAsync(request.Food, cancellationToken)
        };
    }
}