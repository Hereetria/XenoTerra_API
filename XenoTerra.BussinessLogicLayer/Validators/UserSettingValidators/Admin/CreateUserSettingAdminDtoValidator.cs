using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.UserSettingValidators.Admin
{
    public class CreateUserSettingAdminDtoValidator : AbstractValidator<CreateUserSettingAdminDto>
    {
        public CreateUserSettingAdminDtoValidator(IExistenceChecker<UserSetting, CreateUserSettingAdminDto> existenceChecker)
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.LastUpdated)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Last updated time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.UserId
                    ))
                .WithMessage("User setting already exists for this user.");
        }
    }
}
