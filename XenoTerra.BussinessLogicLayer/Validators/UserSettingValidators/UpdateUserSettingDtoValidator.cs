using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.UserSettingValidators
{
    public class UpdateUserSettingDtoValidator : AbstractValidator<UpdateUserSettingDto>
    {
        public UpdateUserSettingDtoValidator()
        {
            RuleFor(x => x.UserSettingId)
                .NotEmpty()
                .WithMessage("UserSettingId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.IsPrivate)
                .NotNull()
                .WithMessage("IsPrivate must not be null.");

            RuleFor(x => x.ReceiveNotifications)
                .NotNull()
                .WithMessage("ReceiveNotifications must not be null.");

            RuleFor(x => x.ShowActivityStatus)
                .NotNull()
                .WithMessage("ShowActivityStatus must not be null.");

            RuleFor(x => x.LastUpdated)
                .NotEmpty()
                .WithMessage("LastUpdated must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("LastUpdated cannot be in the future.");
        }
    }
}
