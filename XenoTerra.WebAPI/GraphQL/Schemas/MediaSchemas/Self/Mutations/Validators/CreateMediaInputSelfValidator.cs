using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Validators
{
    public class CreateMediaInputSelfValidator : AbstractValidator<CreateMediaSelfInput>
    {
        public CreateMediaInputSelfValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("PhotoUrl must not be empty.");
        }
    }
}
