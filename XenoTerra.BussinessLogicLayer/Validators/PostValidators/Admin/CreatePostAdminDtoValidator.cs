using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.PostValidators.Admin
{
    public class CreatePostAdminDtoValidator : AbstractValidator<CreatePostAdminDto>
    {
        public CreatePostAdminDtoValidator()
        {
            RuleFor(x => x.Caption)
                .NotEmpty()
                .WithMessage("Caption is required.");

            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Path is required.");

            RuleFor(x => x.Location)
                .MaximumLength(50)
                .WithMessage("Location is too long.")
                .When(x => x.Location is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Created date cannot be in the future.");
        }
    }
}
