using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types
{
    public class BlockUserWithRelationsType : ObjectType<ResultBlockUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserWithRelationsDto> descriptor)
        {
            descriptor.Name("ResultBlockUserWithRelations");

        }
    }
}
