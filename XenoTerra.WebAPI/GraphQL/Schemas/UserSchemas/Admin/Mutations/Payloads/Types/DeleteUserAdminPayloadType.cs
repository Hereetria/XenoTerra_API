using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteUserAdminPayloadType : ObjectType<DeleteUserAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteUserAdminPayload> descriptor)
        {
        }
    }
}
