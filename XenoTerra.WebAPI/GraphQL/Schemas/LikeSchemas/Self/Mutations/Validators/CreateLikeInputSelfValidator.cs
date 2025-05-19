using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Mutations.Validators
{
    public class CreateLikeInputSelfValidator : AbstractValidator<CreateLikeSelfInput>
    {
        public CreateLikeInputSelfValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
