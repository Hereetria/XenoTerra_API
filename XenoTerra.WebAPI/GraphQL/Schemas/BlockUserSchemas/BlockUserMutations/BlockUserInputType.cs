namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.BlockUserMutations
{
    public class BlockUserInputType : InputObjectType
    {
        protected override void Configure(IInputObjectTypeDescriptor descriptor)
        {
            descriptor.Name("BlockUserInput");
        }
    }
}
