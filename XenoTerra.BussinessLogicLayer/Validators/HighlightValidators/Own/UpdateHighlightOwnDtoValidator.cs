using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators.Own
{
    public class UpdateHighlightOwnDtoValidator : AbstractValidator<UpdateHighlightOwnDto>
    {
        public UpdateHighlightOwnDtoValidator()
        {
            RuleFor(x => x.HighlightId)
                .NotEqual(Guid.Empty)
                .WithMessage("Highlight ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Highlight name cannot be empty.");

            RuleFor(x => x.ProfilePicturePath)
                .NotEmpty()
                .WithMessage("Profile picture path cannot be empty.");
        }
    }
}
