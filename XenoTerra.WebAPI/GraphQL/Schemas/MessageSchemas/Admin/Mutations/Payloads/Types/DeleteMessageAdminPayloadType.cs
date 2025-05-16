using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteMessageAdminPayloadType : ObjectType<DeleteMessageAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteMessageAdminPayload> descriptor)
        {
        }
    }
}
