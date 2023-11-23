using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;
using Shouldly;
using Xunit;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class FoodFixture
{
    [Fact]
    public async Task CanCreateFood()
    {
        var food = new CreateFoodDto { Name = "mike", Color = "white" };

        var beforeCreateFood = await Run<IRepository, int>(async repository =>
            await repository.CountAsync<Foods>(x => true).ConfigureAwait(false));

        beforeCreateFood.ShouldBe(0);

        await _foodsUtil.CreateFood(food);

        var afterUpdateFood = await Run<IRepository, Foods>(async repository =>
            await repository.FirstOrDefaultAsync<Foods>(i => i.Name.Equals("mike")).ConfigureAwait(false));
        
        afterUpdateFood.Name.ShouldBe("mike");
        afterUpdateFood.Color.ShouldBe("white");
    }
}