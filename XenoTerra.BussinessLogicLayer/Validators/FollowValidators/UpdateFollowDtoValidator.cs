using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.FollowValidators
{
    public class UpdateFollowDtoValidator : AbstractValidator<UpdateFollowDto>
    {
        public UpdateFollowDtoValidator()
        {
            RuleFor(x => x.FollowId)
                .NotEmpty()
                .WithMessage("FollowId must not be empty.");

            RuleFor(x => x.FollowerId)
                .NotEmpty()
                .WithMessage("FollowerId must not be empty.");

            RuleFor(x => x.FollowingId)
                .NotEmpty()
                .WithMessage("FollowingId must not be empty.");

            RuleFor(x => x.FollowedAt)
                .NotEmpty()
                .WithMessage("FollowedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("FollowedAt cannot be in the future.");
        }
    }
}
