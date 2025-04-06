using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads.Types
{
    public class CreateBlockUserPayloadType : ObjectType<CreateBlockUserPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<CreateBlockUserPayload> descriptor)
        {
        }
    }
}
