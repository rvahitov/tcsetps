using Autofac;

namespace Correct.Storage.Portal.Autofac
{
    public class PortalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<RestClientModule>();
            builder.RegisterModule<HandlersModule>();
        }
    }
}