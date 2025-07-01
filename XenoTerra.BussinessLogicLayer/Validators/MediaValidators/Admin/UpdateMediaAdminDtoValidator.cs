using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

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

            RuleFor(x => x.SenderId)
                .NotEmpty()
                .WithMessage("Sender Id required")
                .When(x => x.SenderId is not null);

            RuleFor(x => x.ReceiverId)
                .NotEmpty()
                .WithMessage("ReceiverId Id required")
                .When(x => x.ReceiverId is not null);
        }
    }
}
