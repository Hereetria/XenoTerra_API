using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Mutations.Validators
{
    public class CreateMediaInputOwnValidator : AbstractValidator<CreateMediaOwnInput>
    {
        public CreateMediaInputOwnValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty().WithMessage("PhotoUrl must not be empty.");
        }
    }
}
