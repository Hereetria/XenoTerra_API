using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs.Types
{
    public class UpdateCommentInputType : InputObjectType<UpdateCommentInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateCommentInput> descriptor)
        {
        }
    }
}
