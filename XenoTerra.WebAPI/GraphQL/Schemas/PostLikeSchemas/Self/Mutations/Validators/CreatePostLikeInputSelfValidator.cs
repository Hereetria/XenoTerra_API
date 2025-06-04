using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Validators
{
    public class CreatePostLikeInputSelfValidator : AbstractValidator<CreatePostLikeSelfInput>
    {
        public CreatePostLikeInputSelfValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("PostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
        }
    }
}
