using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Validators
{
    public class UpdateSearchHistoryInputSelfValidator : AbstractValidator<UpdateSearchHistorySelfInput>
    {
        public UpdateSearchHistoryInputSelfValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEmpty().WithMessage("SearchHistoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("SearchHistoryId must be a valid GUID.");

            When(x => x.UserId is not null, () =>
            {
                RuleFor(x => x.UserId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("UserId must be a valid GUID.");
            });
        }
    }
}
