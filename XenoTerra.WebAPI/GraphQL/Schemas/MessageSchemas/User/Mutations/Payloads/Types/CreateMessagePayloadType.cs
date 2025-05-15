using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateMessagePayloadType : ObjectType<CreateMessagePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateMessagePayload> descriptor)
        {
        }
    }
}
