using System;
using Autofac;
using FluentValidation;

namespace Correct.Storage.RestApi
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public ValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _container.ResolveOptional(validatorType) as IValidator;
        }
    }
}