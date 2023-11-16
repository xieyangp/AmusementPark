using Mediator.Net.Context;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.Events;
using PractiseForJohnny.Message.Requests;

namespace PractiseForJohnny.Core.Services.Food;

public interface IFoodService : IScopedDependency
{
    Task<CreateFoodEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken);

    Task<UpdateFoodEvent> UpdateFoodAsync(UpdateFoodCommand command, CancellationToken cancellationToken);

    Task<DeleteFoodEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken);

    Task<GetFoodEvent> GetFoodAsync(GetFoodRequest request, CancellationToken cancellationToken);
}