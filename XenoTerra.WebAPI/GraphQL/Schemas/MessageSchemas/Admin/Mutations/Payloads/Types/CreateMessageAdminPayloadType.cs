using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateMessageAdminPayloadType : ObjectType<CreateMessageAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateMessageAdminPayload> descriptor)
        {
        }
    }
}
