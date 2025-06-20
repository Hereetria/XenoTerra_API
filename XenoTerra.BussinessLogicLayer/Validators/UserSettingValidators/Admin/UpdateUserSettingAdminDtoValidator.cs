using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.UserSettingValidators.Admin
{
    public class UpdateUserSettingAdminDtoValidator : AbstractValidator<UpdateUserSettingAdminDto>
    {
        public UpdateUserSettingAdminDtoValidator(IExistenceChecker<UserSetting, UpdateUserSettingAdminDto> existenceChecker)
        {
            RuleFor(x => x.UserSettingId)
                .NotEqual(Guid.Empty)
                .WithMessage("User setting ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId is not null);

            RuleFor(x => x.LastUpdated)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Last updated time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.UserSettingId,
                        x => x.UserId
                    ))
                .WithMessage("User setting already exists for this user.");
        }
    }
}
