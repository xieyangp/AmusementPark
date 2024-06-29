using System.Collections.Concurrent;
using Autofac;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace PractiseForJohnny.IntegarationTests;

public partial class TestBase : TestUtilbase, IAsyncLifetime, IDisposable
{
    private readonly string _testTopic;
    private readonly string _databaseName;

    private static readonly ConcurrentDictionary<string, IContainer> Containers = new();

    private static readonly ConcurrentDictionary<string, bool> shouldRunDbUpDatabases = new();

    protected ILifetimeScope CurrentScope { get; }

    protected IConfiguration CurrentConfiguration => CurrentScope.Resolve<IConfiguration>();
    
    protected TestBase(string testTopic, string databaseName) 
    {
        _testTopic = testTopic;
        _databaseName = databaseName;

        var root = Containers.GetValueOrDefault(testTopic);

        if (root == null)
        {
            var containerBuilder = new ContainerBuilder();
            var configuration = Registerconfiguration(containerBuilder);
            RegisterBaseContainer(containerBuilder, configuration);
            root = containerBuilder.Build();
            Containers[testTopic] = root;
        }

        CurrentScope = root.BeginLifetimeScope();

        RunDbUpIfRequired();
        SetupScope(CurrentScope);
    }
}