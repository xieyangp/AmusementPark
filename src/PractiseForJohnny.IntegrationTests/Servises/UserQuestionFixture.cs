using Mediator.Net.Contracts;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.Core.Domain;
using PractiseForJohnny.IntegarationTests.TestBaseClasses;
using PractiseForJohnny.IntegarationTests.Utills;
using PractiseForJohnny.Message.DTO;
using Shouldly;
using Xunit;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture : FoodBase
{
    private readonly FoodsUtil _foodsUtil;

    public UserQuestionFixture()
    {
        _foodsUtil = new FoodsUtil(CurrentScope);
    }
}