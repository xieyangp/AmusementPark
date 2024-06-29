using AmusementPark.Core.Data;
using AmusementPark.Core.Domain;
using AmusementPark.Message.DTO;
using Shouldly;
using Xunit;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class FoodFixture
{
    [Fact]
    public async Task CanCreateFood()
    {
        var food = new CreateFoodDto { Name = "mike", Color = "white" };

        await Run<IRepository>(async repository =>
        {
            var beforeCreateFood = await repository.CountAsync<Foods>(x => true).ConfigureAwait(false);

            beforeCreateFood.ShouldBe(0);

            await _foodsUtil.CreateFoodAsync(food);

            var afterUpdateFood = await repository.FirstOrDefaultAsync<Foods>(i => i.Name.Equals("mike")).ConfigureAwait(false);
            
            afterUpdateFood?.Color.ShouldBe("white");
            afterUpdateFood?.Name.ShouldBe("mike");
        });
    }
}