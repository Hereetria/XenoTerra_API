using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateAppRoleAdminPayloadType : ObjectType<CreateRoleAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateRoleAdminPayload> descriptor)
        {
        }
    }
}
