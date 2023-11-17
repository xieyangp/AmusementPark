using Mediator.Net.Context;
using Mediator.Net.Contracts;
using Mediator.Net.Pipeline;
using PractiseForJohnny.Core.Data;
using Mediator.Net;

namespace PractiseForJohnny.Core.MiddleWares.UnitOfWork;

public static class UnitOfWorkMiddleWare
{
    public static void UseUnitOfWork<TContext>(this IPipeConfigurator<TContext> configurator,
        IUnitOfWork unitOfWork = null) where TContext : IContext<IMessage>
    {
        if (unitOfWork == null && configurator.DependencyScope == null)
        {
            throw new DependencyScopeNotConfiguredException(
                $"{nameof(unitOfWork)} is not provided and IDependencyScope is not configured, Please ensure {nameof(unitOfWork)} is registered properly if you are using IoC container, otherwise please pass {nameof(unitOfWork)} as parameter");
        }

        unitOfWork ??= configurator.DependencyScope.Resolve<IUnitOfWork>();

        configurator.AddPipeSpecification(new UnifyOfWorkSpacification<TContext>(unitOfWork));
    }
}