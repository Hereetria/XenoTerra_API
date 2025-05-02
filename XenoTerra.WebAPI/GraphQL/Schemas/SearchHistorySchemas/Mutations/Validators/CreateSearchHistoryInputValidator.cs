using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Mutations.Validators
{
    public class CreateSearchHistoryInputValidator : AbstractValidator<CreateSearchHistoryInput>
    {
        public CreateSearchHistoryInputValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
