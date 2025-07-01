using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryValidators.Admin
{
    public class CreateSearchHistoryAdminDtoValidator : AbstractValidator<CreateSearchHistoryAdminDto>
    {
        public CreateSearchHistoryAdminDtoValidator()
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
