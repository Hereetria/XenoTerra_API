using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateAppRoleAdminPayloadType : ObjectType<UpdateRoleAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateRoleAdminPayload> descriptor)
        {
        }
    }
}
