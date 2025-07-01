using FluentValidation;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportPostValidators.Admin
{
    public class CreateReportPostAdminDtoValidator : AbstractValidator<CreateReportPostAdminDto>
    {
        public CreateReportPostAdminDtoValidator(IExistenceChecker<ReportPost, CreateReportPostAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Reporter user ID is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.ReportedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Reported time cannot be in the future.");

            RuleFor(x => x)
            .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(dto, null, x => x.ReporterUserId, x => x.PostId))
                .WithMessage("This post has already been reported by the same user.");
        }
    }
}
