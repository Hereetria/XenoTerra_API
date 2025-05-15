using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Payloads.Types
{
    public class CreatePostPayloadType : ObjectType<CreatePostPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreatePostPayload> descriptor)
        {
        }
    }
}
