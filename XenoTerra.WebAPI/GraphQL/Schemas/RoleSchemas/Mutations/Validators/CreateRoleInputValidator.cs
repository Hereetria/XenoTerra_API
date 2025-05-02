using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Mutations.Validators
{
    public class CreateRoleInputValidator : AbstractValidator<CreateRoleInput>
    {
        public CreateRoleInputValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");
        }
    }
}
