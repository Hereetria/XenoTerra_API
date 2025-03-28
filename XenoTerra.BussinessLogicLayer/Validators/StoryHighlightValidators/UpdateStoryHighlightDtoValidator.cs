using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryHighlightValidators
{
    public class UpdateStoryHighlightDtoValidator : AbstractValidator<UpdateStoryHighlightDto>
    {
        public UpdateStoryHighlightDtoValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty()
                .WithMessage("StoryId must not be empty.");

            RuleFor(x => x.HighlightId)
                .NotEmpty()
                .WithMessage("HighlightId must not be empty.");
        }
    }
}
