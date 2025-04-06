using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads.Types
{
    public class DeleteBlockUserPayloadType : ObjectType<DeleteBlockUserPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteBlockUserPayload> descriptor)
        {
            descriptor.Field(x => x.Success).Type<BooleanType>();
            descriptor.Field(x => x.Message).Type<StringType>();
            descriptor.Field(x => x.Errors).Type<ListType<StringType>>();
            descriptor.Field(x => x.Result).Type<BlockUserType>();
        }
    }
}
