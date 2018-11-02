using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Correct.Storage.Portal.Autofac;

namespace Correct.Storage.Portal
{
    public static class DependencyConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PortalModule>();
            builder.RegisterControllers(typeof(DependencyConfig).Assembly);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}