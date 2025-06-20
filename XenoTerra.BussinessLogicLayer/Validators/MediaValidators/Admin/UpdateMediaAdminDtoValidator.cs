using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators.Admin
{
    public class UpdateMediaAdminDtoValidator : AbstractValidator<UpdateMediaAdminDto>
    {
        public UpdateMediaAdminDtoValidator()
        {
            RuleFor(x => x.MediaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Media ID is required.");

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Photo URL cannot be empty.")
                .When(x => x.PhotoUrl is not null);

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID cannot be empty.")
                .When(x => x.UserId.HasValue);
        }
    }
}
