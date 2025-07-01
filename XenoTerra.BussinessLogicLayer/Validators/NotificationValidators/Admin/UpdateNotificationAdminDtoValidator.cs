using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.NotificationValidators.Admin
{
    public class UpdateNotificationAdminDtoValidator : AbstractValidator<UpdateNotificationAdminDto>
    {
        public UpdateNotificationAdminDtoValidator()
        {
            RuleFor(x => x.NotificationId)
                .NotEqual(Guid.Empty)
                .WithMessage("Notification ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .When(x => x.UserId is not null)
                .WithMessage("User ID cannot be empty if provided.");

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
