using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateCommentInputType : InputObjectType<CreateCommentInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateCommentInput> descriptor)
        {
        }
    }
}
