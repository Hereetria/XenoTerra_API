using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Validators
{
    public class UpdatePostInputValidator : AbstractValidator<UpdatePostInput>
    {
        public UpdatePostInputValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
