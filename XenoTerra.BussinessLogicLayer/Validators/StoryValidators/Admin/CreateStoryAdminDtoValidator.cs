using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryValidators.Admin
{
    public class CreateStoryAdminDtoValidator : AbstractValidator<CreateStoryAdminDto>
    {
        public CreateStoryAdminDtoValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Media path is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Creation time cannot be in the future.");
        }
    }
}
