using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.LikeValidators
{
    public class CreateLikeDtoValidator : AbstractValidator<CreateLikeDto>
    {
        public CreateLikeDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.LikedAt)
                .NotEmpty()
                .WithMessage("LikedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("LikedAt cannot be in the future.");
        }
    }
}
