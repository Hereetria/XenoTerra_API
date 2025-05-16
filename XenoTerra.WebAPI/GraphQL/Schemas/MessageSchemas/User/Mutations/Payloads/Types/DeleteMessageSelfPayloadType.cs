using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteMessageSelfPayloadType : ObjectType<DeleteMessageSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteMessageSelfPayload> descriptor)
        {
        }
    }
}
