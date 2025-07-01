using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportCommentValidators.Admin
{
    public class CreateReportCommentAdminDtoValidator : AbstractValidator<CreateReportCommentAdminDto>
    {
        public CreateReportCommentAdminDtoValidator(IExistenceChecker<ReportComment, CreateReportCommentAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("Reporter user ID is required.");

            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment ID is required.");

            RuleFor(x => x.ReportedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Reported time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.ReporterUserId,
                        x => x.CommentId
                    ))
                .WithMessage("This comment has already been reported by the same user.");
        }
    }
}
