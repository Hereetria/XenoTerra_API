﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryUserValidators
{
    public class CreateSearchHistoryUserDtoValidator : AbstractValidator<CreateSearchHistoryUserDto>
    {
        public CreateSearchHistoryUserDtoValidator()
        {
        }
    }
}
