using Autofac;
using Correct.Storage.Application.Autofac;
using Correct.Storage.DomainStorage.Autofac;

namespace Correct.Storage.RestApi.Autofac
{
    public class RestApiModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule<DataLayerModule>();
            builder.RegisterModule<DomainStorageModule>();
        }
    }
}