using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Mutations.Validators
{
    public class CreateRoleInputAdminValidator : AbstractValidator<CreateRoleAdminInput>
    {
        public CreateRoleInputAdminValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");
        }
    }
}
