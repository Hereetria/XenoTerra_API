using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.AppRoleValidators
{
    public class UpdateAppRoleDtoValidator : AbstractValidator<UpdateAppRoleDto>
    {
        public UpdateAppRoleDtoValidator()
        {
        }
    }
}
