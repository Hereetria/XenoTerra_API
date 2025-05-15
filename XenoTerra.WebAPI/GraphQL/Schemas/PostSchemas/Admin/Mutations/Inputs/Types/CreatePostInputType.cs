using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Mutations.Inputs.Types
{
    public class CreatePostInputType : InputObjectType<CreatePostInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreatePostInput> descriptor)
        {
        }
    }
}
