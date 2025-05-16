using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Validators
{
    public class CreateRecentChatsInputAdminValidator : AbstractValidator<CreateRecentChatsAdminInput>
    {
        public CreateRecentChatsInputAdminValidator()
        {
            RuleFor(x => x.LastMessage)
                .NotEmpty().WithMessage("LastMessage must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
