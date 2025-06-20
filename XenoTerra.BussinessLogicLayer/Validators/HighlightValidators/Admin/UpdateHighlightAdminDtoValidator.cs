using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators.Admin
{
    public class UpdateHighlightAdminDtoValidator : AbstractValidator<UpdateHighlightAdminDto>
    {
        public UpdateHighlightAdminDtoValidator()
        {
            RuleFor(x => x.HighlightId)
                .NotEqual(Guid.Empty)
                .WithMessage("Highlight ID is required.");

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
