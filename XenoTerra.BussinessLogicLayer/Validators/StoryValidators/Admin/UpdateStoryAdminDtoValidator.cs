using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryValidators.Admin
{
    public class UpdateStoryAdminDtoValidator : AbstractValidator<UpdateStoryAdminDto>
    {
        public UpdateStoryAdminDtoValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Media path cannot be empty.")
                .When(x => x.Path is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId is not null);

            RuleFor(x => x.LastUpdated)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Update time cannot be in the future.");
        }
    }
}
