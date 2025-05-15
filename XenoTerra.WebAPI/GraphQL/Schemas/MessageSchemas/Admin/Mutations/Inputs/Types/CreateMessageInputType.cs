using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateMessageInputType : InputObjectType<CreateMessageInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateMessageInput> descriptor)
        {
        }
    }
}
