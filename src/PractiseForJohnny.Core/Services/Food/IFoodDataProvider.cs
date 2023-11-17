using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;

namespace PractiseForJohnny.Core.Services.Food;

public interface IFoodDataProvider : IScopedDependency
{
    Task<Foods> CreatedFoodAsync(Foods food, CancellationToken cancellationToken);

    Task<DeleteFoodDto> DeletedFoodAsync(DeleteFoodDto food, CancellationToken cancellationToken);

    Task UpdatedFoodAsync(UpdateFoodDto food, CancellationToken cancellationToken);

    Task<OutFoodDto> GetFoodAsync(GetFoodDto food, CancellationToken cancellationToken);
}