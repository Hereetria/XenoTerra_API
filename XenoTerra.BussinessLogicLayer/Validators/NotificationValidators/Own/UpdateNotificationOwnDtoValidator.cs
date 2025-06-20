using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.NotificationValidators.Own
{
    public class UpdateNotificationOwnDtoValidator : AbstractValidator<UpdateNotificationOwnDto>
    {
        public UpdateNotificationOwnDtoValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEqual(Guid.Empty)
                .WithMessage("Notification ID is required.");

            RuleFor(x => x.Message)
                .NotEqual(Guid.Empty)
                .When(x => x.Message is not null)
                .WithMessage("Message ID cannot be empty if provided.");

            RuleFor(x => x.Image)
                .NotEmpty()
                .When(x => x.Image is not null)
                .WithMessage("Image cannot be empty if provided.");
        }
    }
}
