using Mediator.Net.Context;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Events;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Food;

public interface IFoodService : IScopedDependency
{
    Task<FoodCreatedEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken);

    Task<FoodUpdatedEvent> UpdateFoodAsync(UpdateFoodCommand command, CancellationToken cancellationToken);

    Task<FoodDeletedEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken);

    Task<FoodGetEvent> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken);
}