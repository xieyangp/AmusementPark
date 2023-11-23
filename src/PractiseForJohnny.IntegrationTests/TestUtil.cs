using System.Reflection;
using Autofac;

namespace PractiseForJohnny.IntegarationTests;

public class TestUtil : TestUtilbase
{
    protected TestUtil(ILifetimeScope scope)
    {
        SetupScope(scope);
    }

    protected string ReadJsonFileFromResource(string resourceName)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

        if (stream == null) return string.Empty;

        using var reader = new StreamReader(stream);

        return reader.ReadToEnd();
    }
}