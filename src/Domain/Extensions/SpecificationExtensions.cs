using System.Linq;
using Akkatecture.Specifications;
using Chessie.ErrorHandling;
using JetBrains.Annotations;
using MediatR;

namespace Correct.Storage.Domain.Extensions
{
    public static class SpecificationExtensions
    {
        public static Result<TResult, string>
            AsChessieResult<T, TResult>([NotNull] this ISpecification<T> specification, [NotNull] T obj,
                TResult successValue)
        {
            var errors = specification.WhyIsNotSatisfiedBy(obj).ToList();
            return errors.Count == 0
                ? Result<TResult, string>.Succeed(successValue)
                : Result<TResult, string>.FailWith(errors);
        }

        public static Result<Unit, string> AsChessieResult<T>([NotNull] this ISpecification<T> specification,
            [NotNull] T obj)
        {
            return AsChessieResult(specification, obj, Unit.Value);
        }
    }
}