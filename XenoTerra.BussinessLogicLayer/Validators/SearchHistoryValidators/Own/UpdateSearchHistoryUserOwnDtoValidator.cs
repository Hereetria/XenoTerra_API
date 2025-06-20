using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators.Own
{
    public class UpdateSearchHistoryOwnDtoValidator : AbstractValidator<UpdateSearchHistoryOwnDto>
    {
        public UpdateSearchHistoryOwnDtoValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Search history ID is required.");

            RuleFor(x => x.SearchedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Search time cannot be in the future.")
                .When(x => x.SearchedAt.HasValue);
        }
    }
}
