using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads.Types
{
    public class CreatePostSelfPayloadType : ObjectType<CreatePostSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreatePostSelfPayload> descriptor)
        {
        }
    }
}
