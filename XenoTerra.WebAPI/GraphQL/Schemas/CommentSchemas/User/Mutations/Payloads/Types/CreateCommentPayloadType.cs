using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateCommentPayloadType : ObjectType<CreateCommentPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateCommentPayload> descriptor)
        {
        }
    }
}
