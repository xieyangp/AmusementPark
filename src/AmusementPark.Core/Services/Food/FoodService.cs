using AmusementPark.Core.Domain;
using AmusementPark.Core.Services.Jobs;
using AmusementPark.Core.Setting.System;
using AutoMapper;
using Hangfire;
using AmusementPark.Message.Commands;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Events;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Services.Food;

public class FoodService : IFoodService
{
    private readonly IMapper _mapper;
    private readonly IFoodDataProvider _foodDataProvider;
    private readonly UpdateFoodJobCron _updateFoodJobCron;
    private readonly IJohnnyBackgroundJobClient _johnnyBackgroundJobClient;

    public FoodService(
        IMapper mapper,
        IFoodDataProvider foodDataProvider,
        UpdateFoodJobCron updateFoodJobCron,
        IJohnnyBackgroundJobClient johnnyBackgroundJobClient)
    {
        _mapper = mapper;
        _foodDataProvider = foodDataProvider;
        _updateFoodJobCron = updateFoodJobCron;
        _johnnyBackgroundJobClient = johnnyBackgroundJobClient;
    }

    public async Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.CreatedFoodAsync(_mapper.Map<Foods>(command.Food), cancellationToken).ConfigureAwait(false);

        return new FoodCreatedEvent
        {
            Result = _mapper.Map<CreateFoodDto>(food)
        };
    }

    public async Task<FoodUpdatedEvent> UpdateFoodAsync(UpdateFoodCommand command, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.UpdateFoodAsync(command.Food, cancellationToken);

        return new FoodUpdatedEvent()
        {
            Result = _mapper.Map<UpdateFoodDto>(food)
        };
    }

    public async Task<FoodDeletedEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.DeletedFoodAsync(command.Food, cancellationToken);

        return new FoodDeletedEvent()
        {
            Result = _mapper.Map<DeleteFoodDto>(food)
        };
    }

    public async Task<OutFoodDto> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.GetFoodAsync(request.Food, cancellationToken);

        return _mapper.Map<OutFoodDto>(food);
    }

    public void DelayCreateFood(DelayCreateFoodCommand command, CancellationToken cancellationToken)
    {
        _johnnyBackgroundJobClient.Enqueue<IFoodDataProvider>(i =>
            i.CreatedFoodAsync(_mapper.Map<Foods>(command.Food), CancellationToken.None));
    }
    
    public void RecurringUpdateFood(RecurringUpdateFoodCommand command, CancellationToken cancellationToken)
    {
        _johnnyBackgroundJobClient.AddOrUpdateRecurringJob<IFoodDataProvider>(
            "updateFoodRecurringJob" + command.Food.Id, i => 
            i.UpdateFoodAsync(_mapper.Map<UpdateFoodDto>(command.Food), CancellationToken.None),
            _updateFoodJobCron.Value, TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
    }
    
    public void ScheduleUpdateFood(ScheduleUpdateFoodCommand command, CancellationToken cancellationToken)
    {
        _johnnyBackgroundJobClient.Schedule<IFoodDataProvider>(i => 
                i.UpdateFoodAsync(_mapper.Map<UpdateFoodDto>(command.Food), CancellationToken.None), 
                TimeSpan.FromMinutes(1));
    }
}