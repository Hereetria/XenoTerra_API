using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteCommentPayloadType : ObjectType<DeleteCommentPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteCommentPayload> descriptor)
        {
        }
    }
}
