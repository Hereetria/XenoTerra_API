using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.NotificationValidators.Admin
{
    public class CreateNotificationAdminDtoValidator : AbstractValidator<CreateNotificationAdminDto>
    {
        public CreateNotificationAdminDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.Message)
                .NotEqual(Guid.Empty)
                .WithMessage("Message ID is required.");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Image cannot be empty.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Creation time cannot be in the future.");
        }
    }
}
