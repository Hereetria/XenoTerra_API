using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Validators
{
    public class CreateUserSettingInputOwnValidator : AbstractValidator<CreateUserSettingOwnInput>
    {
        public CreateUserSettingInputOwnValidator()
        {
        }
    }
}
