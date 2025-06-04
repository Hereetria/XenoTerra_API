using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Validators
{
    public class CreateAppRoleInputAdminValidator : AbstractValidator<CreateRoleAdminInput>
    {
        public CreateAppRoleInputAdminValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");
        }
    }
}
