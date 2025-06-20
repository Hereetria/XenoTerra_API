using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.PostValidators.Own
{
    public class UpdatePostOwnDtoValidator : AbstractValidator<UpdatePostOwnDto>
    {
        public UpdatePostOwnDtoValidator()
        {
            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .WithMessage("Post ID is required.");

            RuleFor(x => x.Caption)
                .MaximumLength(250)
                .WithMessage("Caption is too long.")
                .When(x => x.Caption is not null);

            RuleFor(x => x.Location)
                .MaximumLength(50)
                .WithMessage("Location is too long.")
                .When(x => x.Location is not null);
        }
    }
}
