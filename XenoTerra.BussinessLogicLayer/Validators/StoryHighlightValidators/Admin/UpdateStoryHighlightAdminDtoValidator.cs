using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryHighlightValidators.Admin
{
    public class UpdateStoryHighlightAdminDtoValidator : AbstractValidator<UpdateStoryHighlightAdminDto>
    {
        public UpdateStoryHighlightAdminDtoValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Story ID is required.");

            RuleFor(x => x.HighlightId)
                .NotEqual(Guid.Empty)
                .WithMessage("Highlight ID is required.");
        }
    }
}
