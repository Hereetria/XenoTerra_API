using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Mutations.Validators
{
    public class UpdateReportPostInputOwnValidator : AbstractValidator<UpdateReportPostOwnInput>
    {
        public UpdateReportPostInputOwnValidator()
        {
            RuleFor(x => x.ReportPostId)
                .NotEmpty().WithMessage("ReportPostId must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("ReportPostId must be a valid GUID.");

            When(x => x.PostId is not null, () =>
            {
                RuleFor(x => x.PostId)
                    .Must(ValidationHelper.BeValidGuid).WithMessage("PostId must be a valid GUID.");
            });
        }
    }
}
