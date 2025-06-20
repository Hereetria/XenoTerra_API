using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Mutations.Validators
{
    public class CreateReportStoryInputOwnValidator : AbstractValidator<CreateReportStoryOwnInput>
    {
        public CreateReportStoryInputOwnValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty().WithMessage("StoryId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("StoryId must be a valid GUID.");
        }
    }
}
