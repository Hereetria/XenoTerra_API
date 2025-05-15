using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteMessagePayloadType : ObjectType<DeleteMessagePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteMessagePayload> descriptor)
        {
        }
    }
}
