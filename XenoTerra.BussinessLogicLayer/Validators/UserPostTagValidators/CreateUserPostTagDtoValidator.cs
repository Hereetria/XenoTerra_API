﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.UserPostTagValidators
{
    public class CreateUserPostTagDtoValidator : AbstractValidator<CreateUserPostTagDto>
    {
        public CreateUserPostTagDtoValidator()
        {
        }
    }
}
