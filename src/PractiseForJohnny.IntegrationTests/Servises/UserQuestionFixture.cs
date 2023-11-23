using PractiseForJohnny.IntegarationTests.TestBaseClasses;
using PractiseForJohnny.IntegarationTests.Utills;


namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture : FoodBase
{
    private readonly FoodsUtil _foodsUtil;

    public UserQuestionFixture()
    {
        _foodsUtil = new FoodsUtil(CurrentScope);
    }
}