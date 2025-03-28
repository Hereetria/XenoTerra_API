using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentValidators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content must not be empty.");

            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.CommentedAt)
                .NotEmpty()
                .WithMessage("CommentedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("CommentedAt cannot be in the future.");
        }
    }
}
