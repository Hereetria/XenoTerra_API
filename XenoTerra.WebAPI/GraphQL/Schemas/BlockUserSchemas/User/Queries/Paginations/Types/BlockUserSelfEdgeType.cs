using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations.Types
{
    public class BlockUserSelfEdgeType : ObjectType<BlockUserSelfEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfEdge> descriptor)
        {
        }
    }
}
