using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryUserValidators
{
    public class UpdateSearchHistoryUserDtoValidator : AbstractValidator<UpdateSearchHistoryUserDto>
    {
        public UpdateSearchHistoryUserDtoValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEmpty()
                .WithMessage("SearchHistoryId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");
        }
    }
}
