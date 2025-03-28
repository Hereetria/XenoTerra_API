using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.StoryValidators
{
    public class CreateStoryDtoValidator : AbstractValidator<CreateStoryDto>
    {
        public CreateStoryDtoValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Path must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty()
                .WithMessage("CreatedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("CreatedAt cannot be in the future.");
        }
    }
}
