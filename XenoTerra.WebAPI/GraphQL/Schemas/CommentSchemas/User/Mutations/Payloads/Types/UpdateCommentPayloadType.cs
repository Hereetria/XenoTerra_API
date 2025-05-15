using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateCommentPayloadType : ObjectType<UpdateCommentPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateCommentPayload> descriptor)
        {
        }
    }
}
