using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteCommentSelfPayloadType : ObjectType<DeleteCommentSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteCommentSelfPayload> descriptor)
        {
        }
    }
}
