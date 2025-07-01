using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types.Self.Own
{
    public class BlockUserWithRelationsOwnType : ObjectType<ResultBlockUserWithRelationsOwnDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserWithRelationsOwnDto> descriptor)
        {
            descriptor.Name("ResultBlockUserWithRelationsOwn");

        }
    }
}
