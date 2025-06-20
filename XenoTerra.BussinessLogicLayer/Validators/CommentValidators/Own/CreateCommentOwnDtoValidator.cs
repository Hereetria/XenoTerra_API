using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentValidators.Own
{
    public class CreateCommentOwnDtoValidator : AbstractValidator<CreateCommentOwnDto>
    {
        public CreateCommentOwnDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.CommentedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Commented date cannot be in the future.");

            RuleFor(x => x.ParentCommentId)
                .NotEqual(Guid.Empty)
                .When(x => x.ParentCommentId.HasValue)
                .WithMessage("Parent comment ID cannot be empty.");
        }
    }
}
