using System.Configuration;
using Autofac;
using Correct.Storage.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Correct.Storage.RestApi.Autofac
{
    public class DataLayerModule : Module
    {
        private readonly string _connectionString;
        public DataLayerModule()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ =>
                    new DbContextOptionsBuilder<StorageDbContext>().UseSqlServer(_connectionString).Options)
                .AsSelf();

            builder.Register(ctx => new StorageDbContext(ctx.Resolve<DbContextOptions<StorageDbContext>>()))
                .AsSelf().InstancePerLifetimeScope();
        }
    }
}