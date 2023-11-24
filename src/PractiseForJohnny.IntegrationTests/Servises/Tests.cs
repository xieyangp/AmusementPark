using Xunit.Abstractions;

namespace PractiseForJohnny.IntegarationTests.Servises;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
}