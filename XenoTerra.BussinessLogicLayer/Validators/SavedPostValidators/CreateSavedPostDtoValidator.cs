using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SavedPostValidators
{
    public class CreateSavedPostDtoValidator : AbstractValidator<CreateSavedPostDto>
    {
        public CreateSavedPostDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.PostId)
                .NotEmpty()
                .WithMessage("PostId must not be empty.");

            RuleFor(x => x.SavedAt)
                .NotEmpty()
                .WithMessage("SavedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("SavedAt cannot be in the future.");
        }
    }
}
