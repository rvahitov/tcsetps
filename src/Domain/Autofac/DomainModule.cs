using Akka.Actor;
using Autofac;
using Correct.Storage.Domain.Models.BoxModel;
using Correct.Storage.Domain.Models.BoxModel.Commands;

namespace Correct.Storage.Domain.Autofac
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx =>
                {
                    var actorSystem = ctx.Resolve<ActorSystem>();
                    var props = Props.Create<BoxManager>();
                    return actorSystem.ActorOf(props, "box-manager");
                })
                .Keyed<IActorRef>(AggregateManagers.Box)
                .SingleInstance();


            builder.Register(ctx => new CreateBoxCommandHandler(ctx.ResolveKeyed<IActorRef>(AggregateManagers.Box))).AsImplementedInterfaces();
        }
    }
}