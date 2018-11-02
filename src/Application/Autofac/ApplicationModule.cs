using Akka.Actor;
using Autofac;
using Correct.Storage.Domain.Autofac;

namespace Correct.Storage.Application.Autofac
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(ActorSystem.Create("correct-storage"))
                .As<ActorSystem>()
                .SingleInstance();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<HandlersModule>();
            builder.RegisterModule<MediatorModule>();
            builder.RegisterModule<ValidatorsModule>();
        }
    }
}