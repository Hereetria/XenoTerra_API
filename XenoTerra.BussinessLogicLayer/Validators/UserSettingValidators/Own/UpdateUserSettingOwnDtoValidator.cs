using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.UserSettingValidators.Own
{
    public class UpdateUserSettingOwnDtoValidator : AbstractValidator<UpdateUserSettingOwnDto>
    {
        public UpdateUserSettingOwnDtoValidator()
        {
            RuleFor(x => x.UserSettingId)
                .NotEqual(Guid.Empty)
                .WithMessage("User setting ID is required.");

            RuleFor(x => x.LastUpdated)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Last updated time cannot be in the future.");
        }
    }
}
