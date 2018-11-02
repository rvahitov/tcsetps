using Autofac;
using Correct.Storage.Application.Handlers;
using MediatR;

namespace Correct.Storage.Application.Autofac
{
    internal class HandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new CreateBoxRequestHandler(ctx.Resolve<IMediator>())).AsImplementedInterfaces();
        }
    }
}