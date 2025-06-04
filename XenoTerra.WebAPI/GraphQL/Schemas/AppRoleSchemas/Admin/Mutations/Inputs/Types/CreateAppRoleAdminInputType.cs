using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateAppRoleAdminInputType : InputObjectType<CreateRoleAdminInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateRoleAdminInput> descriptor)
        {
        }
    }
}
