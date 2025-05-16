using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Validators
{
    public class UpdateRoleInputSelfValidator : AbstractValidator<UpdateRoleSelfInput>
    {
        public UpdateRoleInputSelfValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("Id must be a valid GUID.");
        }
    }
}
