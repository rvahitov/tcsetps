using Akka.Actor;
using Autofac;
using Correct.Storage.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Correct.Storage.DomainStorage.Autofac
{
    public class DomainStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StorageInitializer>().As<IStartable>().SingleInstance();
        }

        private class StorageInitializer : IStartable
        {
            private readonly ActorSystem _actorSystem;
            private readonly DbContextOptions<StorageDbContext> _dbContextOptions;

            public StorageInitializer(ActorSystem actorSystem, DbContextOptions<StorageDbContext> dbContextOptions)
            {
                _actorSystem = actorSystem;
                _dbContextOptions = dbContextOptions;
            }

            public void Start()
            {
                var boxStorageProps = Props.Create<BoxStorage>(_dbContextOptions);
                _actorSystem.ActorOf(boxStorageProps, "box-storage");
            }
        }
    }
}