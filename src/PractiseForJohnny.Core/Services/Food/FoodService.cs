using AutoMapper;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Core.Setting.System;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Food;

public class FoodService : IFoodService
{
    private readonly IMapper _mapper;
    private readonly IFoodDataProvider _foodDataProvider;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly UpdateFoodJobCron _updateFoodJobCron;

    public FoodService(
        IMapper mapper,
        IFoodDataProvider foodDataProvider,
        IBackgroundJobClient backgroundJobClient,
        UpdateFoodJobCron updateFoodJobCron)
    {
        _mapper = mapper;
        _foodDataProvider = foodDataProvider;
        _backgroundJobClient = backgroundJobClient;
        _updateFoodJobCron = updateFoodJobCron;
    }

    public async Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var food = await _foodDataProvider.CreatedFoodAsync(_mapper.Map<Foods>(command.Food), cancellationToken)
            .ConfigureAwait(false);

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

    public Task DelayCreateFood(DelayCreateFoodCommand command, CancellationToken cancellationToken)
    {
        _backgroundJobClient.Enqueue<IFoodDataProvider>(i =>
            i.CreatedFoodAsync(_mapper.Map<Foods>(command.Food), CancellationToken.None));

        return Task.CompletedTask;
    }

    public Task RecurringUpdateFood(RecurringUpdateFoodCommand command, CancellationToken cancellationToken)
    {
        RecurringJob.AddOrUpdate<IFoodDataProvider>("updateFoodRecurringJob" + command.Food.Id,
            i => i.UpdateFoodAsync(_mapper.Map<UpdateFoodDto>(command.Food), CancellationToken.None),
            _updateFoodJobCron.Value, new RecurringJobOptions()
            {
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time")
            });
        
        return Task.CompletedTask;
    }

    public Task ScheduleUpdateFood(ScheduleUpdateFoodCommand command, CancellationToken cancellationToken)
    {
        _backgroundJobClient.Schedule<IFoodDataProvider>(
            i => i.UpdateFoodAsync(_mapper.Map<UpdateFoodDto>(command.Food), CancellationToken.None),
            TimeSpan.FromMinutes(1));
        
        return Task.CompletedTask;
    }
}