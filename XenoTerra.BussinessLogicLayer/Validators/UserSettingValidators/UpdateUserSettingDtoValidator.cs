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
        }
    }
}
