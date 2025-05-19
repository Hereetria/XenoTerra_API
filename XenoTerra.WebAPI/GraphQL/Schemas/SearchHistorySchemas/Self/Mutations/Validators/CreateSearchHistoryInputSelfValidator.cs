using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Validators
{
    public class CreateSearchHistoryInputSelfValidator : AbstractValidator<CreateSearchHistorySelfInput>
    {
        public CreateSearchHistoryInputSelfValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
