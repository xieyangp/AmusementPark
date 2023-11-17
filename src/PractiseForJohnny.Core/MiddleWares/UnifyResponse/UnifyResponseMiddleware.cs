using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Pipeline;

namespace PractiseForJohnny.Core.MiddleWares.UnifyResponse;

public static class UnifyResponseMiddleware
{
    public static void UseUnifyResponse<TContext>(this IPipeConfigurator<TContext> configurator)
        where TContext : IContext<IMessage>
    {
        if (configurator.DependencyScope == null)
            throw new ArgumentNullException(nameof(configurator.DependencyScope));

        configurator.AddPipeSpecification(new UnifyResponseSpacification.UnifyResponseSpecification<TContext>());
    }
}

