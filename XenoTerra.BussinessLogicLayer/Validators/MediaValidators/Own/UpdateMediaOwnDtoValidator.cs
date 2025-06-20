using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators.Own
{
    public class UpdateMediaOwnDtoValidator : AbstractValidator<UpdateMediaOwnDto>
    {
        public UpdateMediaOwnDtoValidator()
        {
            RuleFor(x => x.MediaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Media ID is required.");

            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Photo URL cannot be empty.")
                .When(x => x.PhotoUrl is not null);
        }
    }
}
