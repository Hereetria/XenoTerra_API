using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators.Own
{
    public class CreateMediaOwnDtoValidator : AbstractValidator<CreateMediaOwnDto>
    {
        public CreateMediaOwnDtoValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("Photo URL is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.UploadedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Uploaded date cannot be in the future.");
        }
    }
}
