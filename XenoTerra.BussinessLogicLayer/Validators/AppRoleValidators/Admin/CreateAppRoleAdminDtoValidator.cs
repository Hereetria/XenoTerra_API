using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DataAccessLayer.Helpers.Concrete;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.AppRoleValidators.Admin
{
    public class CreateAppRoleAdminDtoValidator : AbstractValidator<CreateAppRoleAdminDto>
    {
        public CreateAppRoleAdminDtoValidator(IExistenceChecker<AppRole, CreateAppRoleAdminDto> existenceChecker)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Role name is required.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.Name!
                    ))
                .WithMessage("A role with the same name already exists.");
        }
    }
}
