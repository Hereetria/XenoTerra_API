namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.BlockUserMutations
{
    public class BlockUserPayloadType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("BlockUserPayload");
        }
    }
}
