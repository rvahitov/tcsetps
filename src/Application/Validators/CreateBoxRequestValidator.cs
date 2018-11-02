using Correct.Storage.Application.Requests;
using FluentValidation;

namespace Correct.Storage.Application.Validators
{
    public class CreateBoxRequestValidator : AbstractValidator<CreateBoxRequest>
    {
        public CreateBoxRequestValidator()
        {
            RuleFor(e => e.Barcode).NotEmpty();
        }
    }
}