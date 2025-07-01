using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators.Admin
{
    public class CreateMediaAdminDtoValidator : AbstractValidator<CreateMediaAdminDto>
    {
        public CreateMediaAdminDtoValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Photo URL is required.");

            RuleFor(x => x.SenderId)
                .NotEqual(Guid.Empty)
                .WithMessage("Sender ID is required.");

            RuleFor(x => x.ReceiverId)
                .NotEqual(Guid.Empty)
                .WithMessage("Receiver ID is required.");

            RuleFor(x => x.UploadedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Uploaded date cannot be in the future.");
        }
    }
}
