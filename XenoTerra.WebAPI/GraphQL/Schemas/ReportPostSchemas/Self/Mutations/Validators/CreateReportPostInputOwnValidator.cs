using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Validators
{
    public class CreateReportPostInputOwnValidator : AbstractValidator<CreateReportPostOwnInput>
    {
        public CreateReportPostInputOwnValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("ReporterUserId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReporterUserId must be a valid GUID.");
        }
    }
}
