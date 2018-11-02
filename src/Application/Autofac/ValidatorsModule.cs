using Autofac;
using Correct.Storage.Application.Validators;

namespace Correct.Storage.Application.Autofac
{
    internal class ValidatorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => new CreateBoxRequestValidator())
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}