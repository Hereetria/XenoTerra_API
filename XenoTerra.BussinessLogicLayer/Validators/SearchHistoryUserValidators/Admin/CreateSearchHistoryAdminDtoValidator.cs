using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Validators.SearchHistoryUserValidators.Admin
{
    public class CreateSearchHistoryUserAdminDtoValidator : AbstractValidator<CreateSearchHistoryUserAdminDto>
    {
        public CreateSearchHistoryUserAdminDtoValidator()
        {
            RuleFor(x => x.SearchHistoryId)
                .NotEqual(Guid.Empty)
                .WithMessage("Search history ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");
        }
    }
}
