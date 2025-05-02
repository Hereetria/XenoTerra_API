using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Validators
{
    public class UpdateRoleInputValidator : AbstractValidator<UpdateRoleInput>
    {
        public UpdateRoleInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("Id must be a valid GUID.");
        }
    }
}
