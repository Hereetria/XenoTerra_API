using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Auth.Inputs.Types
{
    public class LoginInputType : InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
        }
    }
}
