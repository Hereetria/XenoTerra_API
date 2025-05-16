using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Validators
{
    public class CreateSearchHistoryUserInputSelfValidator : AbstractValidator<CreateSearchHistoryUserSelfInput>
    {
        public CreateSearchHistoryUserInputSelfValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEmpty().WithMessage("SearchHistoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SearchHistoryId must be a valid GUID.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
        }
    }
}
