using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Payloads.Types
{
    public class CreateLikeOwnPayloadType : ObjectType<CreatePostLikeOwnPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreatePostLikeOwnPayload> descriptor)
        {
        }
    }
}
