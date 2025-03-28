using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DTOLayer.Dtos.RoleDtos;

namespace XenoTerra.BussinessLogicLayer.Validators.RoleValidators
{
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("RoleId must not be empty.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty.");
        }
    }
}
