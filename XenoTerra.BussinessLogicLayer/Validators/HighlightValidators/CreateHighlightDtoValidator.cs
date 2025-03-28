using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators
{
    public class CreateHighlightDtoValidator : AbstractValidator<CreateHighlightDto>
    {
        public CreateHighlightDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty()
                .WithMessage("ProfilePicturePath must not be empty.");
        }
    }
}
