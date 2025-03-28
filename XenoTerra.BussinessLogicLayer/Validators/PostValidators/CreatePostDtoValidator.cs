using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.PostValidators
{
    public class CreatePostDtoValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty()
                .WithMessage("Caption must not be empty.");

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
