using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportPostDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportPostValidators.Admin
{
    public class UpdateReportPostAdminDtoValidator : AbstractValidator<UpdateReportPostAdminDto>
    {
        public UpdateReportPostAdminDtoValidator(IExistenceChecker<ReportPost, UpdateReportPostAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReportPostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Report post ID is required.");

            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("ReporterUser ID is required.")
                .When(x => x.ReporterUserId is not null);

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.")
                .When(x => x.PostId is not null);

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                {
                    return !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.ReportPostId,
                        x => x.ReporterUserId,
                        x => x.PostId
                    );
                })
                .WithMessage("This post has already been reported by the same user.");
        }
    }
}
