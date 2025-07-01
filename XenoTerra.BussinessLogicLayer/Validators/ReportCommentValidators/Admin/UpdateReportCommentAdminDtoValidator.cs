using AutoMapper;
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
    public class UpdateReportCommentAdminDtoValidator : AbstractValidator<UpdateReportCommentAdminDto>
    {
        public UpdateReportCommentAdminDtoValidator(IExistenceChecker<ReportComment, UpdateReportCommentAdminDto> existenceChecker)
        {
            RuleFor(x => x.ReportCommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Report comment ID is required.");

            RuleFor(x => x.ReporterUserId)
                .NotEqual(Guid.Empty)
                .WithMessage("ReporterUser ID is required.")
                .When(x => x.ReporterUserId is not null);

            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment ID is required.")
                .When(x => x.CommentId is not null);

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                {
                    return !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.ReportCommentId,
                        x => x.ReporterUserId,
                        x => x.CommentId
                    );
                })
                .WithMessage("This comment has already been reported by the same user.");
        }
    }
}
