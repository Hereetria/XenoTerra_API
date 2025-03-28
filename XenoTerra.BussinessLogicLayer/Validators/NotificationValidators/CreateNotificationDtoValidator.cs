using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.NotificationValidators
{
    public class CreateNotificationDtoValidator : AbstractValidator<CreateNotificationDto>
    {
        public CreateNotificationDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Message must not be empty.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty()
                .WithMessage("CreatedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("CreatedAt cannot be in the future.");
        }
    }
}
