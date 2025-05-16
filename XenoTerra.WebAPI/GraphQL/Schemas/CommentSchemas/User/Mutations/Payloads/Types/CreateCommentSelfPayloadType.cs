using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class CreateCommentSelfPayloadType : ObjectType<CreateCommentSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateCommentSelfPayload> descriptor)
        {
        }
    }
}
