using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Validators
{
    public class UpdateMediaInputSelfValidator : AbstractValidator<UpdateMediaSelfInput>
    {
        public UpdateMediaInputSelfValidator()
        {
            RuleFor(x => x.MediaId)
                .NotEmpty().WithMessage("MediaId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("MediaId must be a valid GUID.");
        }
    }
}
