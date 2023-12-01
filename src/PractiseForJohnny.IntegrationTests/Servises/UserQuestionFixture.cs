using PractiseForJohnny.IntegarationTests.TestBaseClasses;
using PractiseForJohnny.IntegarationTests.Utills;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture : UserQuestionFixtureBase
{
    private UserQuestionUtil _userQuestionUtil;
    
    public UserQuestionFixture()
    {
        _userQuestionUtil = new UserQuestionUtil(CurrentScope);
    }
}