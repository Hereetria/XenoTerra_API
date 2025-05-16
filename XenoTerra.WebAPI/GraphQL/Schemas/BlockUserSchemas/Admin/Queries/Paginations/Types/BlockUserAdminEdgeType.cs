using HotChocolate.Types.Pagination;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Queries.Paginations.Types
{
    public class BlockUserAdminEdgeType : ObjectType<BlockUserAdminEdge>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserAdminEdge> descriptor)
        {
        }
    }
}
