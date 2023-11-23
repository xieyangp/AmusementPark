using NSubstitute;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.Message.DTO;
using Shouldly;
using Xunit;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class FoodFixture
{
    [Fact]
    public async Task CanUpdateFood()
    {
        await RunWithUnitOfWork<IRepository>(async repository =>
            await repository.InsertAsync<Foods>(new Foods { Id = 11, Name = "cake", Color = "red" }).ConfigureAwait(false));

        var food = new UpdateFoodDto { Id = 11, Name = "mike", Color = "white" };

        var beforeUpdateFood = await Run<IRepository, Foods>(async repository =>
            await repository.GetByIdAsync<Foods>(11).ConfigureAwait(false));

        beforeUpdateFood.Id.ShouldBe(11);
        beforeUpdateFood.Name.ShouldBe("cake");
        beforeUpdateFood.Color.ShouldBe("red");

        await _foodsUtil.UpdateFood(food);

        var afterUpdateFood = await Run<IRepository, Foods>(async repository =>
            await repository.GetByIdAsync<Foods>(food.Id).ConfigureAwait(false));

        afterUpdateFood.Id.ShouldBe(11);
        afterUpdateFood.Name.ShouldBe("mike");
        afterUpdateFood.Color.ShouldBe("white");
    }

    [Fact]
    public async Task CanDeleteFood()
    {
        await RunWithUnitOfWork<IRepository>(async repository =>
            await repository.InsertAsync<Foods>(new Foods { Id = 11, Name = "cake", Color = "red" }).ConfigureAwait(false));
        
        var food = new DeleteFoodDto() { Id = 11 };

        var beforeDeleteFood = await Run<IRepository, Foods>(async respository =>
            await respository.GetByIdAsync<Foods>(food.Id));

        beforeDeleteFood.Id.ShouldBe(11);

        await _foodsUtil.DeleteFood(food);

        var afterDeleteFood = await Run<IRepository, Foods>(async respository =>
            await respository.GetByIdAsync<Foods>(food.Id));

        afterDeleteFood.ShouldBeNull();
    }

    [Fact]
    public async Task CanGetFood()
    {
        await RunWithUnitOfWork<IRepository>(async repository =>
            await repository.InsertAsync<Foods>(new Foods { Id = 11, Name = "cake", Color = "red" }).ConfigureAwait(false));

        var food = new GetFoodDto { Id = 11 };

        var getFood = await _foodsUtil.GetFood(food);

        getFood.Result.Id.ShouldBe(11);
        getFood.Result.Name.ShouldBe("cake");
        getFood.Result.Color.ShouldBe("red");
    }
}