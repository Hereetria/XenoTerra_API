using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators.Own
{
    public class CreateHighlightOwnDtoValidator : AbstractValidator<CreateHighlightOwnDto>
    {
        public CreateHighlightOwnDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Highlight name cannot be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty()
                .WithMessage("Profile picture path cannot be empty.");
        }
    }
}
