using Xunit;

namespace PractiseForJohnny.IntegarationTests.TestBaseClasses;

[Collection("user_question Test")]
public class UserQuestionFixtureBase : TestBase
{
    protected UserQuestionFixtureBase() : base("user_question", "Test")
    {
    }
}