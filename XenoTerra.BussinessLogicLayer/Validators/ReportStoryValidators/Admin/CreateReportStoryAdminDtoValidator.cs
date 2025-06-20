using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportStoryAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportStoryValidators.Admin
{
    public class CreateReportStoryAdminDtoValidator : AbstractValidator<CreateReportStoryAdminDto>
    {
        public CreateReportStoryAdminDtoValidator(IExistenceChecker<ReportStory, CreateReportStoryAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Reporter user ID is required.");

            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.ReportedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Reported time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.ReporterUserId,
                        x => x.StoryId
                    ))
                .WithMessage("This story has already been reported by the same user.");
        }
    }
}
