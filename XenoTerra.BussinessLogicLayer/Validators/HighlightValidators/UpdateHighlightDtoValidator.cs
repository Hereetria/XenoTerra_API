using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators
{
    public class UpdateHighlightDtoValidator : AbstractValidator<UpdateHighlightDto>
    {
        public UpdateHighlightDtoValidator()
        {
            RuleFor(x => x.HighlightId)
                .NotEmpty()
                .WithMessage("HighlightId must not be empty.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty()
                .WithMessage("ProfilePicturePath must not be empty.");
        }
    }
}
