using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.HighlightValidators.Admin
{
    public class CreateHighlightAdminDtoValidator : AbstractValidator<CreateHighlightAdminDto>
    {
        public CreateHighlightAdminDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Highlight name is required.");
        }
    }
}
