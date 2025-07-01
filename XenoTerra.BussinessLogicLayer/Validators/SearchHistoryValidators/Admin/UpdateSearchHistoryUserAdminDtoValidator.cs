using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators.Admin
{
    public class UpdateSearchHistoryAdminDtoValidator : AbstractValidator<UpdateSearchHistoryAdminDto>
    {
        public UpdateSearchHistoryAdminDtoValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Search history ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.")
                .When(x => x.UserId is not null);

            RuleFor(x => x.SearchedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Search time cannot be in the future.")
                .When(x => x.SearchedAt.HasValue);
        }
    }
}
