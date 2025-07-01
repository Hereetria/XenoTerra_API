using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.NotificationValidators.Own
{
    public class CreateNotificationOwnDtoValidator : AbstractValidator<CreateNotificationOwnDto>
    {
        public CreateNotificationOwnDtoValidator()
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
