using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.CommentDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentValidators.Own
{
    public class UpdateCommentOwnDtoValidator : AbstractValidator<UpdateCommentOwnDto>
    {
        public UpdateCommentOwnDtoValidator()
        {
            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment ID is required.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment content cannot be empty.")
                .When(x => x.Content is not null);
        }
    }
}
