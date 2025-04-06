using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Queries.Types.Paginations
{
    public class BlockUserConnectionType : ObjectType<Connection<ResultBlockUserWithRelationsDto>>
    {
        protected override void Configure(IObjectTypeDescriptor<Connection<ResultBlockUserWithRelationsDto>> descriptor)
        {
        }
    }
}
