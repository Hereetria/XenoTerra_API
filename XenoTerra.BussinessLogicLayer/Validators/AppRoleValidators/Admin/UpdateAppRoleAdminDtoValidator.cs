using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.AppRoleValidators.Admin
{
    public class UpdateAppRoleAdminDtoValidator : AbstractValidator<UpdateAppRoleAdminDto>
    {
        public UpdateAppRoleAdminDtoValidator(IExistenceChecker<AppRole, UpdateAppRoleAdminDto> existenceChecker)
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Role ID is required.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Role name cannot be empty.")
                .When(x => x.Name is not null);

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.Id,
                        x => x.Name!
                    ))
                .WithMessage("A role with the same name already exists.");
        }
    }
}
