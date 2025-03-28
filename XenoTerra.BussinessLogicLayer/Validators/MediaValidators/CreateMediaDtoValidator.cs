using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.MediaValidators
{
    public class CreateMediaDtoValidator : AbstractValidator<CreateMediaDto>
    {
        public CreateMediaDtoValidator()
        {
            RuleFor(x => x.PhotoUrl)
                .NotEmpty()
                .WithMessage("PhotoUrl must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.UploadedAt)
                .NotEmpty()
                .WithMessage("UploadedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("UploadedAt cannot be in the future.");
        }
    }
}
