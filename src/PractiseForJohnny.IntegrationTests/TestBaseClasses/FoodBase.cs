using Xunit;

namespace PractiseForJohnny.IntegarationTests.TestBaseClasses;

[Collection("Food Tests")]

public class FoodBase : TestBase
{
    protected FoodBase() : base("_food_", "Test")
    {
    }
}