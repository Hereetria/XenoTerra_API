﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.UserValidators
{
    public class CreateUserDtoValidator : AbstractValidator<RegisterDto>
    {
        public CreateUserDtoValidator()
        {
        }
    }
}
