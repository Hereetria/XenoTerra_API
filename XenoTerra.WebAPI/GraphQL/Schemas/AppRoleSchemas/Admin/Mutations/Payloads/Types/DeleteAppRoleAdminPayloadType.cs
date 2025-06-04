using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteAppRoleAdminPayloadType : ObjectType<DeleteRoleAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteRoleAdminPayload> descriptor)
        {
        }
    }
}
