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
            RuleFor(x => x.BlockingUserId)
                .NotEqual(x => x.BlockedUserId)
                .WithMessage("A user cannot block themselves.");
        }
    }
}
