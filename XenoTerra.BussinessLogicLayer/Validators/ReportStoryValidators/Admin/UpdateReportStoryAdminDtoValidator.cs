using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportStoryDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportStoryValidators.Admin
{
    public class UpdateReportStoryAdminDtoValidator : AbstractValidator<UpdateReportStoryAdminDto>
    {
        public UpdateReportStoryAdminDtoValidator(IExistenceChecker<ReportStory, UpdateReportStoryAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReportStoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Report story ID is required.");

            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Reporter user ID is required.")
                .When(x => x.ReporterUserId is not null);

            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.")
                .When(x => x.StoryId is not null);

            RuleFor(x => x.ReportedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Reported time cannot be in the future.")
                .When(x => x.ReportedAt.HasValue);

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.ReportStoryId,
                        x => x.ReporterUserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story has already been reported by the same user.");
        }
    }
}
