using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Payloads.Types
{
    public class DeleteBlockUserSelfPayloadType : ObjectType<DeleteBlockUserSelfPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteBlockUserSelfPayload> descriptor)
        {
        }
    }
}
