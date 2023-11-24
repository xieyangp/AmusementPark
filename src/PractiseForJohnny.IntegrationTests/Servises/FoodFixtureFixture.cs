using PractiseForJohnny.IntegarationTests.TestBaseClasses;
using PractiseForJohnny.IntegarationTests.Utills;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class FoodFixture : FoodFixtureBase
{
    private readonly FoodsUtil _foodsUtil;

    public FoodFixture()
    {
        _foodsUtil = new FoodsUtil(CurrentScope);
    }
}