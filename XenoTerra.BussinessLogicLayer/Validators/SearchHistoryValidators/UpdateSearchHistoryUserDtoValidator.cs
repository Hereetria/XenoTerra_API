using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators
{
    public class UpdateSearchHistoryDtoValidator : AbstractValidator<UpdateSearchHistoryDto>
    {
        public UpdateSearchHistoryDtoValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEmpty()
                .WithMessage("SearchHistoryId must not be empty.");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId must not be empty.");

            RuleFor(x => x.SearchedAt)
                .NotEmpty()
                .WithMessage("SearchedAt must not be empty.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("SearchedAt cannot be in the future.");
        }
    }
}
