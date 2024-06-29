using Xunit;

namespace PractiseForJohnny.IntegarationTests.TestBaseClasses;

[Collection("food Tests")]
public class FoodFixtureBase : TestBase
{
    protected FoodFixtureBase() : base("_food_", "Test")
    {
    }
}