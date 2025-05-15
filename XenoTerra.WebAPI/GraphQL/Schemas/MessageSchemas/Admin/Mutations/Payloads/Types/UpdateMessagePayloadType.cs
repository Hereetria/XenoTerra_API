using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateMessagePayloadType : ObjectType<UpdateMessagePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateMessagePayload> descriptor)
        {
        }
    }
}
