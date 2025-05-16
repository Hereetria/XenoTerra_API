using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateCommentAdminPayloadType : ObjectType<CreateCommentAdminPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateCommentAdminPayload> descriptor)
        {
        }
    }
}
