using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs.Types
{
    public class CreateStoryInputType : InputObjectType<CreateStoryInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateStoryInput> descriptor)
        {
        }
    }
}
