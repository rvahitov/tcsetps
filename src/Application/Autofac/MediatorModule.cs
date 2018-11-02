using Autofac;
using MediatR;

namespace Correct.Storage.Application.Autofac
{
    internal class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.Register<ServiceFactory>(ctx =>
            {
                var context = ctx.Resolve<IComponentContext>();
                return t => context.ResolveOptional(t);
            });
        }
    }
}