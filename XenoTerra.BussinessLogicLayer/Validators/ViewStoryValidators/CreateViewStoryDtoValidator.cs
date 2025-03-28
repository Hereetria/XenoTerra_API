using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.ViewStoryValidators
{
    public class CreateViewStoryDtoValidator : AbstractValidator<CreateViewStoryDto>
    {
        public CreateViewStoryDtoValidator()
        {
            RuleFor(x => x.StoryId)
                .NotEmpty()
                .WithMessage("StoryId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.ViewedAt)
                .NotEmpty()
                .WithMessage("ViewedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("ViewedAt cannot be in the future.");
        }
    }
}
