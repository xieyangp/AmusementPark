using System.Net;
using PractiseForJohnny.Core.Data;
using PractiseForJohnny.IntegarationTests.TestBaseClasses;
using PractiseForJohnny.IntegarationTests.Utills;
using PractiseForJohnny.Message.Enum;
using PractiseForJohnny.Message.Requests;
using Shouldly;
using Xunit;

namespace PractiseForJohnny.IntegarationTests.Servises;

public partial class UserQuestionFixture : UserQuestionFixtureBase
{
    private UserQuestionUtil _userQuestionUtil;
    
    public UserQuestionFixture()
    {
        _userQuestionUtil = new UserQuestionUtil(CurrentScope);
    }
}