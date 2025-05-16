using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteCommentAdminPayloadType : ObjectType<DeleteCommentAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteCommentAdminPayload> descriptor)
        {
        }
    }
}
