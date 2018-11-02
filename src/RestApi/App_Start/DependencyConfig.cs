using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Correct.Storage.RestApi.Autofac;
using FluentValidation.WebApi;

namespace Correct.Storage.RestApi
{
    public static class DependencyConfig
    {
        public static void Configure(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new RestApiModule());
            builder.RegisterApiControllers(typeof(DependencyConfig).Assembly);
            var container = builder.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            FluentValidationModelValidatorProvider.Configure(httpConfiguration,
                provider => { provider.ValidatorFactory = new ValidatorFactory(container); });
        }
    }
}