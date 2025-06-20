using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads.Types
{
    public class CreateLikeOwnPayloadType : ObjectType<CreateCommentLikeOwnPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateCommentLikeOwnPayload> descriptor)
        {
        }
    }
}
