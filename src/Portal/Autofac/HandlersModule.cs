using Autofac;
using Correct.Storage.Portal.Handlers;
using RestSharp;

namespace Correct.Storage.Portal.Autofac
{
    public class HandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new CreateBoxRequestHandler(ctx.Resolve<IRestClient>()))
                .AsImplementedInterfaces();
        }
    }
}