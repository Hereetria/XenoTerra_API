using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ReportCommentValidators
{
    public class CreateReportCommentDtoValidator : AbstractValidator<CreateReportCommentDto>
    {
        public CreateReportCommentDtoValidator()
        {
            RuleFor(x => x.ReporterUserId)
                .NotEmpty()
                .WithMessage("ReporterUserId must not be empty.");

            RuleFor(x => x.CommentId)
                .NotEmpty()
                .WithMessage("CommentId must not be empty.");

            RuleFor(x => x.Reason)
                .NotEmpty()
                .WithMessage("Reason must not be empty.");

            RuleFor(x => x.ReportedAt)
                .NotEmpty()
                .WithMessage("ReportedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("ReportedAt cannot be in the future.");
        }
    }
}
