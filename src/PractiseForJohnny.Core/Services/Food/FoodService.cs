using Microsoft.EntityFrameworkCore;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.Commands;
using PractiseForJohnny.Message.DTO;
using PractiseForJohnny.Message.Events;

namespace PractiseForJohnny.Core.Services.Food;

public class FoodService : IFoodService
{
    private readonly PratiseForJohnnyDbContext _pratiseForJohnnyDbContext;

    public FoodService(PratiseForJohnnyDbContext pratiseForJohnnyDbContext)
    {
        _pratiseForJohnnyDbContext = pratiseForJohnnyDbContext;
    }

    public async Task<CreateFoodEvent> CreateFoodAsync(CreateFoodCommand command, CancellationToken cancellationToken)
    {
        var food = new Foods()
        {
            Name = command.Food.Name,
            Color = command.Food.Color
        };

        await _pratiseForJohnnyDbContext.AddAsync(food, cancellationToken).ConfigureAwait(false);

        var result = await _pratiseForJohnnyDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0
            ? "添加成功"
            : "添加失败";

        return new CreateFoodEvent
        {
            Result = result
        };
    }

    public async Task<UpdateFoodEvent> UpdateFoodAsync(UpdateFoodCommand command,CancellationToken cancellationToken)
    {
        var commandFood = command.Food;
        var food= await _pratiseForJohnnyDbContext.FindAsync<Foods>(commandFood.Id).ConfigureAwait(false);
        food.Name = commandFood.Name;
        food.Color = commandFood.Color;

        _pratiseForJohnnyDbContext.Update(food);
        
        var result = await _pratiseForJohnnyDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0
            ? "修改成功"
            : "修改失败";
        
        return new UpdateFoodEvent()
        {
            Result = result
        };
    }

    public async Task<DeleteFoodEvent> DeleteFoodAsync(DeleteFoodCommand command, CancellationToken cancellationToken)
    {
        var commandFood = command.Food;
        var food = await _pratiseForJohnnyDbContext.FindAsync<Foods>(commandFood.Id).ConfigureAwait(false);
      
        _pratiseForJohnnyDbContext.Remove(food);
        
        var result = await _pratiseForJohnnyDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false) > 0
            ? "删除成功"
            : "删除失败";
       
        return new DeleteFoodEvent()
        {
            Result = result
        };
    }

    public async Task<GetFoodEvent> GetFoodAsync(GetFoodCommand command, CancellationToken cancellationToken)
    {
        var commandFood = command.Food;
        var food = await _pratiseForJohnnyDbContext.FindAsync<Foods>(commandFood.Id);

        var result = new OutFoodDto()
        {
            Id = food.Id,
            Name = food.Name,
            Color = food.Color
        };

        return new GetFoodEvent
        {
            Result = result
        };
    }
}