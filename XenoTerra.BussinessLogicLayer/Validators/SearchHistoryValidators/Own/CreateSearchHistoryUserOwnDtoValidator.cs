using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators.Own
{
    public class CreateSearchHistoryOwnDtoValidator : AbstractValidator<CreateSearchHistoryOwnDto>
    {
        public CreateSearchHistoryOwnDtoValidator()
        {
            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.SearchedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Search time cannot be in the future.");
        }
    }
}
