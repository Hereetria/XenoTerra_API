using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Mutations.Validators
{
    public class UpdateMediaInputAdminValidator : AbstractValidator<UpdateMediaAdminInput>
    {
        public UpdateMediaInputAdminValidator()
        {
            RuleFor(x => x.MediaId)
                .NotEmpty().WithMessage("MediaId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MediaId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
