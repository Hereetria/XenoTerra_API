using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Payloads.Types
{
    public class UpdateCommentSelfPayloadType : ObjectType<UpdateCommentSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<UpdateCommentSelfPayload> descriptor)
        {
        }
    }
}
