using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.BlockUserValidators
{
    public class UpdateBlockUserDtoValidator : AbstractValidator<UpdateBlockUserDto>
    {
        public UpdateBlockUserDtoValidator()
        {
            RuleFor(x => x.BlockUserId)
                .NotEmpty()
                .WithMessage("BlockUserId must not be empty.");

            RuleFor(x => x.BlockingUserId)
                .NotEmpty()
                .WithMessage("BlockingUserId must not be empty.");

            RuleFor(x => x.BlockedUserId)
                .NotEmpty()
                .WithMessage("BlockedUserId must not be empty.");

            RuleFor(x => x.BlockedAt)
                .NotEmpty()
                .WithMessage("BlockedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("BlockedAt cannot be in the future.");
        }
    }
}
