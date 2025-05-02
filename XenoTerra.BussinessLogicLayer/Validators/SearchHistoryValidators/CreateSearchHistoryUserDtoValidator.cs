using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators
{
    public class CreateSearchHistoryDtoValidator : AbstractValidator<CreateSearchHistoryDto>
    {
        public CreateSearchHistoryDtoValidator()
        {
        }
    }
}
