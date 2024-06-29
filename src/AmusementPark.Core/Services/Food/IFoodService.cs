using Mediator.Net.Context;
using AmusementPark.Core.Domain;
using AmusementPark.Message.Commands;
using AmusementPark.Message.DTO;
using AmusementPark.Message.Events;
using AmusementPark.Message.Requests;

namespace AmusementPark.Core.Services.Food;

public interface IFoodService : IScopedDependency
{
    Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken);

    Task<FoodUpdatedEvent> UpdateFoodAsync(UpdateFoodCommand command, CancellationToken cancellationToken);

    Task<FoodDeletedEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken);

    Task<OutFoodDto> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken);

    void DelayCreateFood(DelayCreateFoodCommand command, CancellationToken cancellationToken);

    void RecurringUpdateFood(RecurringUpdateFoodCommand command, CancellationToken cancellationToken);

    void ScheduleUpdateFood(ScheduleUpdateFoodCommand command, CancellationToken cancellationToken);
}