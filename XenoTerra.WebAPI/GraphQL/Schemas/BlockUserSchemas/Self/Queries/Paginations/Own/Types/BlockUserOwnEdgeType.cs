using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Queries.Paginations.Own.Types
{
    public class BlockUserOwnEdgeType : ObjectType<BlockUserOwnEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserOwnEdge> descriptor)
        {
        }
    }
}
