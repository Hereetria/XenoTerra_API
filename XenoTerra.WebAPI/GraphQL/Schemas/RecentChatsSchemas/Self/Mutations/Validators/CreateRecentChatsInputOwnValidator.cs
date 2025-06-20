using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Mutations.Validators
{
    public class CreateRecentChatsInputOwnValidator : AbstractValidator<CreateRecentChatsOwnInput>
    {
        public CreateRecentChatsInputOwnValidator()
        {
            RuleFor(x => x.LastMessage)
                .NotEmpty().WithMessage("LastMessage must not be empty.");
        }
    }
}
