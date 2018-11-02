using Autofac;
using MediatR;

namespace Correct.Storage.Portal.Autofac
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.Register<ServiceFactory>(context =>
            {
                var ctx = context.Resolve<IComponentContext>();
                return t => ctx.ResolveOptional(t);
            });
        }
    }
}