using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.PostValidators.Admin
{
    public class UpdatePostAdminDtoValidator : AbstractValidator<UpdatePostAdminDto>
    {
        public UpdatePostAdminDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.Caption)
                .MaximumLength(250)
                .WithMessage("Caption is too long.")
                .When(x => x.Caption is not null);

            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Path cannot be empty.")
                .When(x => x.Path is not null);

            RuleFor(x => x.Location)
                .MaximumLength(50)
                .WithMessage("Location is too long.")
                .When(x => x.Location is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.")
                .When(x => x.UserId.HasValue);
        }
    }
}
