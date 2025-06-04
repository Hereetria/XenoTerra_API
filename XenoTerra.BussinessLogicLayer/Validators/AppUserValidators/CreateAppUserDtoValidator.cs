using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.AppUserValidators
{
    public class CreateAppUserDtoValidator : AbstractValidator<RegisterDto>
    {
        public CreateAppUserDtoValidator()
        {
        }
    }
}
