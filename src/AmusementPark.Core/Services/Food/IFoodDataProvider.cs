using AmusementPark.Core.Domain;
using AmusementPark.Message.DTO;

namespace AmusementPark.Core.Services.Food;

public interface IFoodDataProvider : IScopedDependency
{
    Task<Foods> CreatedFoodAsync(Foods food, CancellationToken cancellationToken);

    Task<Foods> DeletedFoodAsync(DeleteFoodDto food, CancellationToken cancellationToken);

    Task<Foods> UpdateFoodAsync(UpdateFoodDto food, CancellationToken cancellationToken);

    Task<Foods> GetFoodAsync(GetFoodDto food, CancellationToken cancellationToken);
}